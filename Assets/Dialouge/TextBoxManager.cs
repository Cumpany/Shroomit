using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject TalkText;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public Movement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();

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

    public void CurrentLineUpdate()
    {
        currentLine += 1;

        if (currentLine > textLines.Length - 1)
        {
            textBox.SetActive(false);
            TalkText.SetActive(true);
            currentLine = 0;
        }
    }

    public void ActivateTextBox()
    {
        textBox.SetActive(true);
    }
}
