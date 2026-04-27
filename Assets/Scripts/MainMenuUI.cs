using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public RectTransform settingsButton;
    private bool isPortrait;

    void Start()
    {
        ApplyLayout();
    }

    void Update()
    {
        bool currentPortrait = Screen.height >= Screen.width;

        if (currentPortrait != isPortrait)
        {
            ApplyLayout();
        }
    }

    void ApplyLayout()
    {
        isPortrait = Screen.height >= Screen.width;

        if (isPortrait)
        {
            Vector2 pos = settingsButton.anchoredPosition;
            pos.y = 1460;
            settingsButton.anchoredPosition = pos;
        }
        else
        {
            Vector2 pos = settingsButton.anchoredPosition;
            pos.y = 590;
            settingsButton.anchoredPosition = pos;
        }
    }
    public void ShowPanel(GameObject panelToShow)
    {
        panelToShow.SetActive(true);
    }

    public void ClosePanel(GameObject panelToShow)
    {
        panelToShow.SetActive(false);
    }

    public void SetXSprite(Sprite newSprite) 
    { 
        GameSettings.Instance.selectedXSprite = newSprite; 
    }

    public void SetOSprite(Sprite newSprite)
    {
        GameSettings.Instance.selectedOSprite = newSprite;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game scene");

        if (isPortrait)
        {
            Vector2 pos = settingsButton.anchoredPosition;
            pos.y = 520f;
            settingsButton.anchoredPosition = pos;
        }
    }

    public void ExitGame() { 
        Application.Quit();
        Debug.Log("Exit clicked");
    }
    
}
