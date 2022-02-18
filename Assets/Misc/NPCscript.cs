using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{
    public GameObject TalkText;
    public static bool TextActive;

    public static bool inRange;

    public AudioSource gay;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;
    public AudioClip audioClip5;


    void Start()
    {
        gay.clip = audioClip1;
        TalkText.SetActive(false);
    }

    void Update()
    {
        int random = Random.Range(1, 6);
        ChangeAudio(random);
       

        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
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

    void ChangeAudio(int i)
    {
        string s = i.ToString();
        switch (s)
        {
            case "1":
                gay.clip = audioClip1;
                break;
            case "2":
                gay.clip = audioClip2;
                break;
            case "3":
                gay.clip = audioClip3;
                break;
            case "4":
                gay.clip = audioClip4;
                break;
            case "5":
                gay.clip = audioClip5;
                break;
            default:
                Debug.LogWarning("No audio");
                break;

        }
    }
}
