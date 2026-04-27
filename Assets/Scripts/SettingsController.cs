using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public static SettingsController Instance;
    public Toggle musicToggle;
    public Toggle sfxToggle;
    public GameObject panel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Open()
    {
        panel.SetActive(true);

        musicToggle.isOn = AudioManager.Instance.IsMusicOn();
        sfxToggle.isOn = AudioManager.Instance.IsSFXOn();
    }

    public void Close()
    {
        panel.SetActive(false);
    }
}