using UnityEngine;
[RequireComponent(typeof(UFOPawn))]
public class UFOAIController : MonoBehaviour
{
    public bool usePhysicsMovement = false;
    public float physicsForce = 8f;
    public float rotationSpeed = 2f;
    public float minDistance = 1f;

    UFOPawn pawn;
    Rigidbody rb;
    Transform player;

    void Awake()
    {
        pawn = GetComponent<UFOPawn>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        //try by tag
        var go = GameObject.FindGameObjectWithTag("Player");
        if (go != null) { player = go.transform; return; }

        // fallback: find any ShipPawn instance
        var ship = FindFirstObjectByType<ShipPawn>();
        if (ship != null) { player = ship.transform; return; }

        Debug.LogWarning("[UFOAIController] Player not found in scene. Make sure the player is tagged 'Player' or a ShipPawn exists.");
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            // track UFO instance in scene
            if (Time.frameCount % 60 == 0) FindPlayer();
            return;
        }

        Vector3 toPlayer = (player.position - transform.position);
        float dist = toPlayer.magnitude;
        Vector3 dir = toPlayer.normalized;

        if (dir.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime);
        }

        if (usePhysicsMovement && rb != null)
        {
            if (dist > minDistance)
            {
                rb.AddForce(transform.forward * physicsForce, ForceMode.Acceleration);
            }
        }
        else
        {
            if (dist > minDistance)
            {
                transform.position += transform.forward * pawn.moveSpeed * Time.fixedDeltaTime;
            }
        }
    }

    // call from GameManager after player respawn to re-track
    public void RefreshTarget()
    {
        FindPlayer();
    }
}
