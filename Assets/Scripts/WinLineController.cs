using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinLineController : MonoBehaviour
{
    public RectTransform line;
    public float animTime = 0.25f;
    
    public void ShowLine(Vector2 pos, float rotationZ, float finalWidth)
    {
        gameObject.SetActive(true);

        line.anchoredPosition = pos;
        line.rotation = Quaternion.Euler(0, 0, rotationZ);
        line.sizeDelta = new Vector2(0, line.sizeDelta.y);

        StartCoroutine(Animate(finalWidth));
    }
    IEnumerator Animate(float targetWidth)
    {
        float t = 0f;

        while (t < animTime)
        {
            t += Time.deltaTime;
            float width = Mathf.Lerp(0, targetWidth, t / animTime);

            line.sizeDelta =
                new Vector2(width, line.sizeDelta.y);

            yield return null;
        }

        line.sizeDelta =
            new Vector2(targetWidth, line.sizeDelta.y);
    }

    public void HideLine()
    {
        gameObject.SetActive(false);
    }
}