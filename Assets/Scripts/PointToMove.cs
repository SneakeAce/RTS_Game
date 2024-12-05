using System.Collections.Generic;
using UnityEngine;

public class PointToMove : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    private const int MaxPoints = 5;
    private Queue<Vector3> _points;

    private bool _isReadyPoint;

    public Queue<Vector3> Points { get => _points; set => _points = value; }
    public Unit Unit { get => _unit; }
    public bool IsReadyPoint { get => _isReadyPoint; }

    private void Start()
    {
        _points = new Queue<Vector3>(MaxPoints);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _points.Count < MaxPoints)
        {
            Debug.Log("PointToMove");
            _isReadyPoint = false;

            _points.Clear();

            _points.Enqueue(GetPoint());
        }
    }

    private Vector3 GetPoint()
    {
        Vector3 point = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            point = hitInfo.point;
        }

        _isReadyPoint = true;

        return point;
    }



}
