using UnityEngine;

public interface ICameraController
{
    void MoveTo(Transform target, float moveSpeed, float rotationSpeed);
    bool IsAtPosition(Transform target);
}