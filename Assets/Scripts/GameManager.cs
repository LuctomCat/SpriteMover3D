using UnityEngine;
//fix
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Player")]
    public GameObject playerPawnPrefab;
    public Transform playerParent;
    public Vector3 playerSpawnPosition = Vector3.zero;

    [Header("Gameplay")]
    public int startingLives = 3;
    public int lives;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        lives = startingLives;
    }

    void Start()
    {
        // Spawn player at coordinates
        //if (playerPawnPrefab != null)
            //SpawnPlayer();
    }

    public GameObject SpawnPlayer()
    {
        if (playerPawnPrefab == null)
        {
            Debug.LogError("GameManager: playerPawnPrefab not assigned!");
            return null;
        }

        GameObject go = Instantiate(playerPawnPrefab, playerSpawnPosition, Quaternion.identity,
            playerParent != null ? playerParent : null);
        return go;
    }

    // Call death
    public void OnPlayerDestroyed()
    {
        // Lives counter
        lives = Mathf.Max(0, lives - 1);
        Debug.Log("Player destroyed. Lives remaining: " + lives);
        // will add respawning in a bit
    }
}
