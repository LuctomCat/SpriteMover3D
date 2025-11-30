using UnityEngine;
public class PlayerDeathRelay : MonoBehaviour
{
    [HideInInspector] public LivesManager livesManager;

    // call this when the player actually dies (before or after Destroy on the player)
    public void NotifyDied()
    {
        if (livesManager != null)
            livesManager.PlayerDied();
        else
            Debug.LogWarning("[PlayerDeathRelay] No LivesManager found to notify.");
    }
}
