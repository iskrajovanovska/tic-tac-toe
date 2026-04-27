using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text totalGamesText;
    public Text xWinsText;
    public Text oWinsText;
    public Text drawsText;
    public Text averageTimeText;

    void OnEnable()
    {
        RefreshStats();
    }

    public void RefreshStats()
    {
        totalGamesText.text = StatsManager.Instance.totalGames.ToString();
        xWinsText.text = StatsManager.Instance.player1Wins.ToString();
        oWinsText.text = StatsManager.Instance.player2Wins.ToString();
        drawsText.text = StatsManager.Instance.draws.ToString();
        averageTimeText.text =
            StatsManager.Instance.GetAverageGameTime().ToString("F1") + " s";
    }
}