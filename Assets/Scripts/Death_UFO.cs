using UnityEngine;

public class Death_UFO : Death
{
    public AudioClip deathSound;

    public override void Die()
    {
        if (AudioManager.Instance != null && deathSound != null)
        AudioManager.Instance.PlaySfxAt(transform.position, deathSound);

        Destroy(gameObject);
    }
}
