using UnityEngine;
using UnityEngine.UI; //allows me to use textboxes and buttons in the script
using System;

public class GameMenuUI : MonoBehaviour
{
    Boolean checker;
    int movesX = 0;
    int movesO = 0;

    public void OnCellClicked(Button clickedButton)
    {
        if ((movesX + movesO) % 2 == 0) //even number of previous moves, means that X is next
        {
            Image img = clickedButton.GetComponent<Image>();

            if (img.sprite != null) return; // already clicked

            img.sprite = GameSettings.Instance.selectedXSprite;

            clickedButton.interactable = false;

            movesX += 1;
        }
        else { //...otherwise it is O
            Image img = clickedButton.GetComponent<Image>();

            if (img.sprite != null) return; // already clicked

            img.sprite = GameSettings.Instance.selectedOSprite;

            clickedButton.interactable = false;

            movesO += 1;
        }
    }

}
