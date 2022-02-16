using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightAreas : MonoBehaviour
{
    int x;

    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        img.color = new Color(0, 0.042f, 0.34f, 0);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        // fades the image out when you click
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(FadeImage(true));
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        x++;
        // fade from opaque to transparent
        if (x % 2 == 0 && fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 0.5f; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0.042f, 0.34f, i);
                yield return null;
            }
        }
    }
}
