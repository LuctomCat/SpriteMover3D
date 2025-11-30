using UnityEngine;
using System.Collections.Generic;

public class LevelData : MonoBehaviour
{
    [Header("Y-Axis Limit")]
    public float maxY = 30f;

    [Header("Spawn Counts")]
    public int numUFOs = 3;
    public int numAstronauts = 5;
    public int numHealthPacks = 3;

    [Header("Collect Spawn Points Automatically")]
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    void Awake()
    {
        spawnPoints.Clear();
        spawnPoints.AddRange(GetComponentsInChildren<SpawnPoint>());
    }

    public Vector3 ClampY(Vector3 pos)
    {
        if (pos.y > maxY)
            return new Vector3(pos.x, maxY, pos.z);
        return pos;
    }
}
