using UnityEngine;
// fix
public class DamageOnCollision : MonoBehaviour
{
    public float damageAmount = 100f;
    public bool onlyDamagePlayer = false;

    void OnCollisionEnter(Collision collision)
    {
        if (onlyDamagePlayer && !collision.collider.CompareTag("Player")) return;

        Health h = collision.collider.GetComponentInParent<Health>();
        if (h != null)
        {
            h.TakeDamage(damageAmount);
        }
    }
}
