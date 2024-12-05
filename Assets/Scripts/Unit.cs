using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    [SerializeField] private float _speed;

    private IPoint _point;

    public Transform Transform => transform;

    public float Speed => _speed;

    public bool IsMoving { get; set; }

    private void Update()
    {
        _point?.Update();
    }

    public void SetPointToMove(IPoint point)
    {
        _point?.StopMoveToPoint();

        _point = point;

        _point.StartMoveToPoint();
    }
}
