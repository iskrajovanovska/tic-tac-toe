using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public Sprite selectedXSprite;
    public Sprite selectedOSprite;

    public void SetXSprite(Sprite newSprite)
    {
        selectedXSprite = newSprite;
    }

    public void SetOSprite(Sprite newSprite)
    {
        selectedOSprite = newSprite;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (selectedXSprite == null)
            {
                Debug.Log("No X sprite selected, using default");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
