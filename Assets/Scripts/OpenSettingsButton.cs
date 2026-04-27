using UnityEngine;

public class OpenSettingsButton : MonoBehaviour
{
    public void OpenSettings()
    {
        SettingsController.Instance.Open();
    }
}