using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public enum CellState { Empty, X, O }

    [Header("Game Over UI")]
    public GameObject gameOverPopup;
    public Text resultText;
    public Text durationText;

    [Header("Board")]
    public Button[] cells;
    public Image[] cellImages;
    Sprite selectedXSprite;
    Sprite selectedOSprite;

    [Header("Game Settings")]
    public float matchDuration;
    public Text p1MovesText;
    public Text p2MovesText;

    private CellState[] board = new CellState[9];
    private bool isPlayer1Turn = true;
    private int moveCount = 0;
    private bool gameEnded = false;

    private float startTime;
    private int p1Moves = 0;
    private int p2Moves = 0;

    public AudioClip clickClip;

    public WinLineController winLine;

    private void Start()
    {
        selectedXSprite = GameSettings.Instance.selectedXSprite;
        selectedOSprite = GameSettings.Instance.selectedOSprite;

        InitGame();
    }

    void InitGame()
    {
        startTime = Time.time;

        isPlayer1Turn = true;
        moveCount = 0;
        gameEnded = false;
        p1Moves = 0;
        p2Moves = 0;

        p1MovesText.text = "0";
        p2MovesText.text = "0";

        for (int i = 0; i < 9; i++)
        {
            board[i] = CellState.Empty;
            cellImages[i].gameObject.SetActive(false);
            cells[i].interactable = true;

            int index = i;
            cells[i].onClick.RemoveAllListeners();
            cells[i].onClick.AddListener(() => OnCellClicked(index));

            cells[i].onClick.AddListener(() =>
            {
                AudioManager.Instance.PlaySFX(clickClip);
            });
        }
    }

    void OnCellClicked(int index)
    {
        AudioManager.Instance.PlaySFX(clickClip);

        if (gameEnded || board[index] != CellState.Empty)
            return;

        cellImages[index].gameObject.SetActive(true);

        if (isPlayer1Turn)
        {
            board[index] = CellState.X;
            cellImages[index].sprite = selectedXSprite;
            p1Moves++;
            p1MovesText.text = p1Moves.ToString();
        }
        else
        {
            board[index] = CellState.O;
            cellImages[index].sprite = selectedOSprite;
            p2Moves++;
            p2MovesText.text = p2Moves.ToString();
        }

        cells[index].interactable = false;
        moveCount++;

        int winIndex = CheckWin();

        if (winIndex != -1)
        {
            ShowWinningLine(winIndex);
            EndGame(isPlayer1Turn ? 1 : 2);
            return;
        }

        if (moveCount >= 9)
        {
            EndGame(0);
            return;
        }

        isPlayer1Turn = !isPlayer1Turn;
    }

    int CheckWin()
    {
        int[,] winPatterns = new int[,]
        {
        {0,1,2}, {3,4,5}, {6,7,8},
        {0,3,6}, {1,4,7}, {2,5,8},
        {0,4,8}, {2,4,6}
        };

        for (int i = 0; i < winPatterns.GetLength(0); i++)
        {
            int a = winPatterns[i, 0];
            int b = winPatterns[i, 1];
            int c = winPatterns[i, 2];

            if (board[a] != CellState.Empty &&
                board[a] == board[b] &&
                board[a] == board[c])
            {
                return i;
            }
        }

        return -1;
    }

    void EndGame(int winner)
    {
        gameEnded = true;
        float duration = Time.time - startTime;
        foreach (var cell in cells)
            cell.interactable = false;

        if (winner == 1)
            StatsManager.Instance.RegisterWin(1, duration);
        else if (winner == 2)
            StatsManager.Instance.RegisterWin(2, duration);
        else
            StatsManager.Instance.RegisterDraw(duration);

        gameOverPopup.SetActive(true);

        if (winner == 1)
            resultText.text = "Player 1 Wins";
        else if (winner == 2)
            resultText.text = "Player 2 Wins";
        else
            resultText.text = "Draw";

        durationText.text = "Time: " + duration.ToString("F2") + "s";
    }

    public void Retry()
    {
        gameOverPopup.SetActive(false);
        winLine.HideLine();
        InitGame();
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    void ShowWinningLine(int index)
    {
        switch (index)
        {
            case 0:
                winLine.ShowLine(new Vector2(0, 200), 0, 600);
                break;
            case 1:
                winLine.ShowLine(new Vector2(0, 0), 0, 600);
                break;
            case 2:
                winLine.ShowLine(new Vector2(0, -200), 0, 600);
                break;
            case 3:
                winLine.ShowLine(new Vector2(-200, 0), 90, 600);
                break;
            case 4:
                winLine.ShowLine(new Vector2(0, 0), 90, 600);
                break;
            case 5:
                winLine.ShowLine(new Vector2(200, 0), 0, 600);
                break;
            case 6:
                winLine.ShowLine(Vector2.zero, -45, 846);
                break;
            case 7:
                winLine.ShowLine(Vector2.zero, 45, 846);
                break;
        }
    }
}