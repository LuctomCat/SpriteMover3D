using UnityEngine;
//fix
public class ShipController : MonoBehaviour
{
    public ShipPawn pawn;

    [Header("Input")]
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.D;
    public KeyCode yawLeftKey = KeyCode.A;
    public KeyCode yawRightKey = KeyCode.S;
    public KeyCode rollLeftKey = KeyCode.Q;
    public KeyCode rollRightKey = KeyCode.E;
    public KeyCode pitchUpKey = KeyCode.Z;
    public KeyCode pitchDownKey = KeyCode.X;
    public KeyCode fireKey = KeyCode.Space;

    void Update()
    {
        if (pawn == null) return;

        // Forward and Backward
        float throttle = (Input.GetKey(forwardKey) ? 1f : 0f) + (Input.GetKey(backwardKey) ? -1f : 0f);
        pawn.ApplyThrottle(throttle);

        // Left and Right
        float yaw = (Input.GetKey(yawLeftKey) ? 1f : 0f) + (Input.GetKey(yawRightKey) ? -1f : 0f);
        pawn.ApplyYaw(yaw);

        // Tilting Left and Right
        float roll = (Input.GetKey(rollLeftKey) ? 1f : 0f) + (Input.GetKey(rollRightKey) ? -1f : 0f);
        pawn.ApplyRoll(roll);

        // Tilting Up and Down
        float pitch = (Input.GetKey(pitchUpKey) ? 1f : 0f) + (Input.GetKey(pitchDownKey) ? -1f : 0f);
        pawn.ApplyPitch(pitch);

        // Shooting
        if (Input.GetKeyDown(fireKey))
            pawn.Fire();
    }
}
