using UnityEngine;
//fix
[RequireComponent(typeof(Rigidbody))]
public class ShipPawn : MonoBehaviour
{
    [Header("Physics")]
    public Rigidbody rb;
    public float thrustForce = 30f;
    public float pitchTorque = 5f;
    public float yawTorque = 5f;
    public float rollTorque = 5f;

    [Header("Camera")]
    [Tooltip("Local direction (in local space) from the ship to the camera (direction only). Set in inspector.")]
    public Vector3 cameraOffsetDirection = new Vector3(0f, 2f, -6f);
    [Tooltip("Look-at offset in front of the ship (local). Camera will look at transform.TransformPoint(lookAtOffset).")]
    public Vector3 cameraLookAtOffset = new Vector3(0f, 1f, 4f);

    [Header("Shooting")]
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed = 40f;
    public float projectileLifetime = 5f;

    //Auto assigns rigidbody in case I forget
    void Reset()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    // Movement API
    public void ApplyThrottle(float throttle)
    {
        if (rb == null) return;
        Vector3 force = Vector3.forward * throttle * thrustForce;
        rb.AddRelativeForce(force, ForceMode.Acceleration);
    }

    public void ApplyYaw(float yaw)
    {
        if (rb == null) return;
        Vector3 torque = Vector3.up * yaw * yawTorque;
        rb.AddRelativeTorque(torque, ForceMode.Acceleration);
    }

    public void ApplyPitch(float pitch)
    {
        if (rb == null) return;
        Vector3 torque = Vector3.right * pitch * pitchTorque;
        rb.AddRelativeTorque(torque, ForceMode.Acceleration);
    }

    public void ApplyRoll(float roll)
    {
        if (rb == null) return;
        Vector3 torque = Vector3.forward * roll * rollTorque;
        rb.AddRelativeTorque(torque, ForceMode.Acceleration);
    }

    public void Fire()
    {
        if (projectilePrefab == null || projectileSpawn == null) return;

        GameObject p = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
        Rigidbody prb = p.GetComponent<Rigidbody>();
        if (prb != null)
        {
            prb.linearVelocity = projectileSpawn.forward * projectileSpeed;
        }
        Destroy(p, projectileLifetime);
    }
}
