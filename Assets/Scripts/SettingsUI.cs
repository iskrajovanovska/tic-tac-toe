using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;

    private void Start()
    {
        musicToggle.isOn = AudioManager.Instance.IsMusicOn();
        sfxToggle.isOn = AudioManager.Instance.IsSFXOn();

        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
        sfxToggle.onValueChanged.AddListener(OnSFXToggleChanged);
    }

    private void OnMusicToggleChanged(bool value)
    {
        AudioManager.Instance.ToggleMusic(value);
    }

    private void OnSFXToggleChanged(bool value)
    {
        AudioManager.Instance.ToggleSFX(value);
    }

}