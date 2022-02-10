using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentances;
    public void Start()
    {
        sentances = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("started converstation with" + dialogue.name);
    }

    public void Test()
    {
        Debug.Log("hafsodfgay");
    }
}
