using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{
    public GameObject TalkText;

    bool inRange;

    void Start()
    {
        TalkText.SetActive(false);
    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                FindObjectOfType<TextBoxManager>().ActivateTextBox();
                TalkText.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TalkText.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TalkText.SetActive(false);
            inRange = false;
        }
    }
}
