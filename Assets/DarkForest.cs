using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DarkForest : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    public Image img;

    void Start()
    {
        img.color = new Color(0, 0.042f, 0.34f, 0);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(true));
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(false));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            Debug.Log("gfyau<asfuoh");
            for (float i = 0.5f; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0.042f, 0.34f, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            Debug.Log("ikv103");
            for (float i = 0; i <= 0.5; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0.042f, 0.34f, i);
                yield return null;
            }
        }
    }
}
