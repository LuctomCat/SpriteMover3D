using UnityEngine;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text healthText;
    public TMP_Text livesText;

    [Header("Player References")]
    public LivesManager livesManager;

    private Health playerHealth;

    private void Update()
    {
        // Always check if player exists
        if (playerHealth == null)
        {
            var playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                playerHealth = playerObj.GetComponent<Health>();
        }

        UpdateHealthUI();
        UpdateLivesUI();
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            if (playerHealth != null)
            {
                float percent = Mathf.Clamp01(playerHealth.currentHealth / Mathf.Max(1f, playerHealth.maxHealth));
                healthText.text = $"Health: {Mathf.RoundToInt(percent * 100f)}%";
            }
            else
            {
                // Player destroyed, show 0
                healthText.text = "Health: 0%";
            }
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText != null && livesManager != null)
        {
            livesText.text = $"Lives: {livesManager.GetLives()}";
        }
    }
}
