using UnityEngine;
//fix

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float damage = 25f;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Apply damage to health value
        Health h = collision.collider.GetComponentInParent<Health>();
        if (h != null)
        {
            h.TakeDamage(damage);
        }

        // Destroy when Health is 0
        Destroy(gameObject);
    }
}
