using UnityEngine;
// fix
public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;

    [Header("Offset Settings")]
    public Vector3 offsetDirection = new Vector3(0, 2, -6);
    public float minDistance = 3f;
    public float maxDistance = 10f;
    private float currentDistance;

    [Header("Camera Follow")]
    public float followSmoothness = 5f;
    public Vector3 lookAtOffset = new Vector3(0, 1, 0);

    void Start()
    {
        currentDistance = offsetDirection.magnitude;
    }

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPosition = target.TransformPoint(offsetDirection.normalized * currentDistance);

        // Follows behind the ship
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSmoothness * Time.deltaTime);

        // Faces the player ship
        Vector3 lookTarget = target.position + target.TransformDirection(lookAtOffset);
        transform.LookAt(lookTarget);
    }
}
