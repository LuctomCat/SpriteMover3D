using UnityEngine;
//fix
public class ShipDeath : Death
{
    public override void Die()
    {
        // Notifies Gamemanager on Player Death
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnPlayerDestroyed();
        }

        // Destroys Player
        Destroy(gameObject);
    }
}
