using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject talkText;
    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public Movement player;

    bool HasTalkedToAbbis = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();

        player.CanMove = true;

        textBox.SetActive(false);

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = textLines[currentLine];
    }
    void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.Space) && textBox.activeSelf)
        {
            CurrentLineUpdate();
        }
    }

    public void CurrentLineUpdate()
    {
        currentLine += 1;

        if (currentLine > textLines.Length - 1)
        {
            if (!HasTalkedToAbbis)
            {
                PlayerInventory.AnyInvSlot((ItemList.Items)5);
            }
            player.CanMove = true;
            talkText.SetActive(true);
            textBox.SetActive(false);
            currentLine = 0;
            HasTalkedToAbbis = true;
        }
    }

    public void ActivateTextBox()
    {   
        player.CanMove = false;
        textBox.SetActive(true);
    }
}
