using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("SFX Settings")]
    public AudioSource oneShotSource;
    public GameObject sfx3DPrefab;

    [Header("Music")]
    public AudioSource musicSource;     // looping background music

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //  2D sounds for UI and pickups
    public void PlaySfx(AudioClip clip)
    {
        if (clip == null || oneShotSource == null) return;
        oneShotSource.PlayOneShot(clip);
    }

    //  3D sounds at world position
    public void PlaySfxAt(Vector3 position, AudioClip clip, float volume = 1f)
    {
        if (clip == null)
            return;

        // If you have a prefab, use it for proper 3D audio
        if (sfx3DPrefab != null)
        {
            GameObject obj = Instantiate(sfx3DPrefab, position, Quaternion.identity);
            AudioSource src = obj.GetComponent<AudioSource>();
            if (src == null) src = obj.AddComponent<AudioSource>();

            src.clip = clip;
            src.volume = volume;
            src.spatialBlend = 1f; // full 3D audio
            src.Play();

            Destroy(obj, clip.length + 0.1f);
            return;
        }

        // fallback: PlayClipAtPoint
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }


    //  music setup
    public void PlayMusic(AudioClip track)
    {
        if (musicSource == null || track == null) return;

        musicSource.clip = track;
        musicSource.loop = true;
        musicSource.Play();
    }
}
