using UnityEngine;

public class ResponsiveUI : MonoBehaviour
{
    public RectTransform boardPanel;
    public RectTransform hudPanel;

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
            SetPortrait();
        else
            SetLandscape();
    }

    void SetPortrait()
    {
        // BOARD = top-middle
        boardPanel.anchorMin = new Vector2(0.5f, 0.72f);
        boardPanel.anchorMax = new Vector2(0.5f, 0.72f);
        boardPanel.pivot = new Vector2(0.5f, 0.5f);
        boardPanel.anchoredPosition = Vector2.zero;

        // HUD = bottom-middle
        hudPanel.anchorMin = new Vector2(0.5f, 0.20f);
        hudPanel.anchorMax = new Vector2(0.5f, 0.20f);
        hudPanel.pivot = new Vector2(0.5f, 0.5f);
        hudPanel.anchoredPosition = Vector2.zero;
    }

    void SetLandscape()
    {
        // BOARD = middle-left
        boardPanel.anchorMin = new Vector2(0.28f, 0.5f);
        boardPanel.anchorMax = new Vector2(0.28f, 0.5f);
        boardPanel.pivot = new Vector2(0.5f, 0.5f);
        boardPanel.anchoredPosition = Vector2.zero;

        // HUD = middle-right
        hudPanel.anchorMin = new Vector2(0.76f, 0.5f);
        hudPanel.anchorMax = new Vector2(0.76f, 0.5f);
        hudPanel.pivot = new Vector2(0.5f, 0.5f);
        hudPanel.anchoredPosition = Vector2.zero;
    }
}