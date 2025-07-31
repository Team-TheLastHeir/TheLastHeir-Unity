using UnityEngine;

public class SimpleCameraController : MonoBehaviour, ICameraController
{
    public Transform cameraTransform;

    public void MoveTo(Transform target, float moveSpeed, float rotationSpeed)
    {
        cameraTransform.position = Vector3.MoveTowards(
            cameraTransform.position,
            target.position,
            moveSpeed * Time.deltaTime);

        cameraTransform.rotation = Quaternion.Slerp(
            cameraTransform.rotation,
            target.rotation,
            rotationSpeed * Time.deltaTime);
    }

    public bool IsAtPosition(Transform target)
    {
        return Vector3.Distance(cameraTransform.position, target.position) < 0.05f;
    }
}