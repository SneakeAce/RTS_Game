using UnityEngine;

public interface IUnit
{
    Transform Transform { get; }
    float Speed { get; }
    bool IsMoving { get; set; }
}
