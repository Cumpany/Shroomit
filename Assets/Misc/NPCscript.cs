using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{
    public GameObject TalkText;
    public static bool TextActive;

    public static bool inRange;

    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;
    public AudioClip audioClip5;

    public int ok;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        TalkText.SetActive(false);
    }

    void Update()
    {
        ok = 1;
        ChangeAudio(ok, 1);
       

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

    void ChangeAudio(int i, int x)
    {
        ok += x;
        if (ok > 5)
        {
            ok = 1;
        }
        string s = i.ToString();
        switch (s)
        {
            case "1":
                audioSource.clip = audioClip1;
                break;
            case "2":
                audioSource.clip = audioClip2;
                break;
            case "3":
                audioSource.clip = audioClip3;
                break;
            case "4":
                audioSource.clip = audioClip4;
                break;
            case "5":
                audioSource.clip = audioClip5;
                break;
            default:
                Debug.LogWarning("No audio");
                break;

        }
    }
}
