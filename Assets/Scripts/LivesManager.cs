using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    [Header("Player Settings")]
    public GameObject playerPrefab;
    public Transform playerSpawnPoint;
    public int startingLives = 3;
    public float respawnDelay = 1f;

    private int currentLives;
    private GameObject currentPlayer;

    private void Awake()
    {
        currentLives = startingLives;
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        if (currentLives <= 0)
        {
            LoadGameOver();
            return;
        }

        if (playerPrefab == null || playerSpawnPoint == null)
        {
            Debug.LogError("[LivesManager] Player prefab or spawn point not assigned!");
            return;
        }

        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }

        currentPlayer = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
        currentPlayer.tag = "Player";

        // Hook into player's Health component
        var health = currentPlayer.GetComponent<Health>();
        if (health != null)
        {
            health.onDeath = OnPlayerDeath;
        }
    }

    // Internal death handler
    private void OnPlayerDeath()
    {
        currentLives--;
        Debug.Log($"[LivesManager] Player died. Lives left: {currentLives}");

        if (currentLives <= 0)
        {
            LoadGameOver();
        }
        else
        {
            StartCoroutine(RespawnAfterDelay());
        }
    }
    public void PlayerDied()
    {
        OnPlayerDeath();
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnPlayer();
    }

    private void LoadGameOver()
    {
        Debug.Log("[LivesManager] Player out of lives. Loading GameOver scene.");
        SceneManager.LoadScene("GameOverScreen");
    }

    // Get current lives
    public int GetLives() => currentLives;
}
