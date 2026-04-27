using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void StatsProvide() {
        /*totalGamesText.text = StatsManager.Instance.GetTotalGames().ToString();
        p1WinsText.text = StatsManager.Instance.GetPlayer1Wins().ToString();
        p2WinsText.text = StatsManager.Instance.GetPlayer2Wins().ToString();
        drawsText.text = StatsManager.Instance.GetDraws().ToString();

        avgTimeText.text = StatsManager.Instance.GetAverageGameTime().ToString("F2");*/
    }

    public void ExitGame() { 
        Application.Quit();
        Debug.Log("Exit clicked");
    }
    
}
