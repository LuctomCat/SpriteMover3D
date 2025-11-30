using UnityEngine;

public class PlayerYLimiter : MonoBehaviour
{
    LevelData level;

    void Start()
    {
        level = FindFirstObjectByType<LevelData>();
    }

    void LateUpdate()
    {
        if (level == null) return;

        transform.position = level.ClampY(transform.position);
    }
}
