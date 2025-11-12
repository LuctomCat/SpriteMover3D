using UnityEngine;
//fix
public class LevelData : MonoBehaviour
{
    [Header("Level Size (meters)")]
    public Vector3 levelSize = new Vector3(100f, 100f, 100f);

    [Header("Ground")]
    public Transform groundTransform;

    [Header("Notes / Designer data")]
    [TextArea]
    public string notes;
}
