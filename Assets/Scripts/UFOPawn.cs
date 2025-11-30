using UnityEngine;

[RequireComponent(typeof(Health))]
public class UFOPawn : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float contactDamage = 50f;

    // other audio/healthbar fields can live here as before

    // Called by projectile or other damage systems:
    public void ReceiveDamage(float amount)
    {
        // Use the existing Health component
        Health h = GetComponent<Health>();
        if (h != null)
            h.TakeDamage(amount);
    }

    // Contact with player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == null) return;

        // check player by tag or by ShipPawn presence
        if (collision.collider.CompareTag("Player") || collision.collider.GetComponentInParent<ShipPawn>() != null)
        {
            Health hp = collision.collider.GetComponentInParent<Health>();
            if (hp != null)
                hp.TakeDamage(contactDamage);
        }
    }
}
