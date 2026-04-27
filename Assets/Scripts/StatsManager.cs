using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    public int totalGames;
    public int player1Wins;
    public int player2Wins;
    public int draws;
    public float totalGameTime;

    private void Awake()
    {
        Debug.Log("StatsManager Awake");
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadStats();
    }

    public void RegisterWin(int player, float duration)
    {
        totalGames++;
        totalGameTime += duration;

        if (player == 1)
            player1Wins++;
        else if (player == 2)
            player2Wins++;

        SaveStats();
    }

    public void RegisterDraw(float duration)
    {
        totalGames++;
        totalGameTime += duration;
        draws++;

        SaveStats();
    }

    public int GetTotalGames() => totalGames;
    public int GetPlayer1Wins() => player1Wins;
    public int GetPlayer2Wins() => player2Wins;
    public int GetDraws() => draws;

    public float GetAverageGameTime()
    {
        if (totalGames == 0) return 0f;
        return totalGameTime / totalGames;
    }

    private void SaveStats()
    {
        PlayerPrefs.SetInt("TotalGames", totalGames);
        PlayerPrefs.SetInt("P1Wins", player1Wins);
        PlayerPrefs.SetInt("P2Wins", player2Wins);
        PlayerPrefs.SetInt("Draws", draws);
        PlayerPrefs.SetFloat("TotalTime", totalGameTime);
        PlayerPrefs.Save();
    }

    private void LoadStats()
    {
        totalGames = PlayerPrefs.GetInt("TotalGames", 0);
        player1Wins = PlayerPrefs.GetInt("P1Wins", 0);
        player2Wins = PlayerPrefs.GetInt("P2Wins", 0);
        draws = PlayerPrefs.GetInt("Draws", 0);
        totalGameTime = PlayerPrefs.GetFloat("TotalTime", 0f);
    }
}