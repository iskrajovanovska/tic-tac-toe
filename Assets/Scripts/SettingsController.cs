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
        Debug.Log("SETTINGS AWAKE: " + gameObject.name);

        if (Instance != null && Instance != this)
        {
            Debug.Log("DESTROYING DUPLICATE: " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Open()
    {
        Debug.Log("OPEN CALLED");
        panel.SetActive(true);

        musicToggle.isOn = AudioManager.Instance.IsMusicOn();
        sfxToggle.isOn = AudioManager.Instance.IsSFXOn();
    }

    public void Close()
    {
        Debug.Log("CLOSE CALLED");
        panel.SetActive(false);
    }
}