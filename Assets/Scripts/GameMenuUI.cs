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

            CheckGameState();
        }
        else { //...otherwise it is O
            Image img = clickedButton.GetComponent<Image>();

            if (img.sprite != null) return; // already clicked

            img.sprite = GameSettings.Instance.selectedOSprite;

            clickedButton.interactable = false;

            movesO += 1;

            CheckGameState();
        }
    }

    /*
     using UnityEngine;
using UnityEngine.UI; // Required for Image and Button components

public class SpriteMatcher : MonoBehaviour {
    public Button myButton;
    public Sprite selectedSprite; // The sprite you want to check against

    public void CheckSpriteMatch() {
        // Access the Image component's sprite property
        Sprite buttonSprite = myButton.GetComponent<Image>().sprite;

        if (buttonSprite == selectedSprite) {
            Debug.Log("The sprites match!");
        } else {
            Debug.Log("The sprites do not match.");
        }
    }
}



            // Find the GameObject named "MyButtonName" and get its Button component
        Button myButton = GameObject.Find("MyButtonName").GetComponent<Button>();

        if (myButton != null) {
            myButton.onClick.AddListener(() => Debug.Log("Button clicked!"));
        }
     */

    public void CheckGameState()
    {


    }
}
