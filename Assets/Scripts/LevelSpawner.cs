using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour
{
    [Header("Prefabs to Spawn")]
    public GameObject ufoPrefab;
    public GameObject astronautPrefab;
    public GameObject healthPackPrefab;

    [Header("Scene Spawn Points")]
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    private void Start()
    {
        foreach (SpawnPoint sp in spawnPoints)
        {
            SpawnAt(sp);
        }
    }

    private void SpawnAt(SpawnPoint sp)
    {
        GameObject prefabToSpawn = null;

        switch (sp.spawnType)
        {
            case SpawnPoint.SpawnType.UFO: prefabToSpawn = ufoPrefab; break;
            case SpawnPoint.SpawnType.Astronaut: prefabToSpawn = astronautPrefab; break;
            case SpawnPoint.SpawnType.HealthPack: prefabToSpawn = healthPackPrefab; break;
        }

        if (prefabToSpawn != null)
        {
            sp.spawnedObject = Instantiate(prefabToSpawn, sp.transform.position, sp.transform.rotation);
            StartCoroutine(WaitForDespawn(sp));
        }
    }

    private IEnumerator WaitForDespawn(SpawnPoint sp)
    {
        while (sp.spawnedObject != null)
        {
            yield return null; // wait until the object is destroyed
        }

        // Wait the respawn delay
        yield return new WaitForSeconds(sp.respawnDelay);

        // Respawn
        SpawnAt(sp);
    }
}
