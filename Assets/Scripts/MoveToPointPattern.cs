using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveToPointPattern : IPoint
{
    private const float MinDistanceToPoint = 0.05f;

    private Queue<Vector3> _points;
    private Vector3 _point;
    private Unit _unit;

    public MoveToPointPattern(IEnumerable<Vector3> points, Unit unit)
    {
        _points = new Queue<Vector3>(points);
        _unit = unit;
    }

    public void StartMoveToPoint()
    {
        _point = _points.Dequeue();

        _unit.IsMoving = true;
    }

    public void StopMoveToPoint()
    {
        _unit.IsMoving = false;
    }

    public void Update()
    {
        if (_unit.IsMoving == false)
            return;

        _unit.Transform.DOMove(_point, _unit.Speed);

        if (Vector3.Distance(_unit.transform.position, _point) <= MinDistanceToPoint)
        {
            StopMoveToPoint();
        }
    }
}
