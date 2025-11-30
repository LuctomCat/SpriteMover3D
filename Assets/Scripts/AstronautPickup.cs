using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AstronautPickup : MonoBehaviour
{
    public int scoreValue = 50;
    public AudioClip pickupSfx;

    void OnTriggerEnter(Collider other) { TryPickup(other.gameObject); }
    void OnCollisionEnter(Collision collision) { TryPickup(collision.gameObject); }

    void TryPickup(GameObject other)
    {
        if (other == null) return;

        // detect player
        var ship = other.GetComponentInParent<ShipPawn>();
        if (ship == null && !other.CompareTag("Player")) return;

        // add score safely
        if (ScoreManager.Instance != null)
        ScoreManager.Instance.AddScore(scoreValue);
        else if (GameManager.Instance != null)
        ScoreManager.Instance.AddScore(scoreValue);


        if (pickupSfx != null && AudioManager.Instance != null)
            AudioManager.Instance.PlaySfxAt(transform.position, pickupSfx);
        
        Destroy(gameObject);


    }
}
