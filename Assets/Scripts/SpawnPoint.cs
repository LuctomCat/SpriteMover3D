using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public enum SpawnType { UFO, Astronaut, HealthPack }
    public SpawnType spawnType = SpawnType.UFO;

    [Header("Respawn Settings")]
    public float respawnDelay = 5f; // seconds after object is destroyed

    [HideInInspector]
    public GameObject spawnedObject; // reference to the currently spawned object
}
