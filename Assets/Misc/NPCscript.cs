using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{
    public GameObject TestButton;

    void Start()
    {
        TestButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<TextBoxManager>().ActivateTextBox();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TestButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TestButton.SetActive(false);
        }
    }
}
