using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMovePattern : MonoBehaviour
{
    [SerializeField] private PointToMove _pointToMove;

    private Unit _unit;

    private void Update()
    {
        if (_pointToMove.Points.Count > 0 && _pointToMove.IsReadyPoint)
        {
            if (Input.GetMouseButtonDown(1)) 
            {
                _unit = _pointToMove.Unit;
                ChoicePatternMove();
            }
        }
    }

    private void ChoicePatternMove()
    {
        _unit.SetPointToMove(new MoveToPointPattern(_pointToMove.Points, _unit));
    }
}
