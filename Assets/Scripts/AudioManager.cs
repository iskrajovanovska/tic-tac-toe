using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    private bool musicOn = true;
    private bool sfxOn = true;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSettings();
    }

    private void Start()
    {
        ApplySettings();
    }

    // -------------------------
    // PUBLIC METHODS
    // -------------------------

    public void ToggleMusic(bool value)
    {
        musicOn = value;
        bgmSource.mute = !musicOn;
        SaveSettings();
    }

    public void ToggleSFX(bool value)
    {
        sfxOn = value;
        sfxSource.mute = !sfxOn;
        SaveSettings();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (!sfxOn || clip == null) return;

        sfxSource.PlayOneShot(clip);
    }

    public bool IsMusicOn()
    {
        return musicOn;
    }

    public bool IsSFXOn()
    {
        return sfxOn;
    }

    // -------------------------
    // PRIVATE METHODS
    // -------------------------

    private void ApplySettings()
    {
        bgmSource.mute = !musicOn;
        sfxSource.mute = !sfxOn;
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetInt("Music", musicOn ? 1 : 0);
        PlayerPrefs.SetInt("SFX", sfxOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        musicOn = PlayerPrefs.GetInt("Music", 1) == 1;
        sfxOn = PlayerPrefs.GetInt("SFX", 1) == 1;
    }
}