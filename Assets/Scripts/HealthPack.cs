using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HealthPack : MonoBehaviour
{
    public float healAmount = 25f;
    public AudioClip pickupSfx;

    void OnTriggerEnter(Collider other) { TryPickup(other.gameObject); }
    void OnCollisionEnter(Collision collision) { TryPickup(collision.gameObject); }

    void TryPickup(GameObject other)
    {
        if (other == null) return;

        // Detect player by component or by tag
        var ship = other.GetComponentInParent<ShipPawn>();
        var h = other.GetComponentInParent<Health>();

        if (ship == null && (other.CompareTag("Player") == false))
            return;

        if (h != null)
        {
            h.Heal(healAmount);
            if (pickupSfx != null) AudioManager.Instance?.PlaySfxAt(transform.position, pickupSfx);
            Destroy(gameObject);
        }
    }
}
