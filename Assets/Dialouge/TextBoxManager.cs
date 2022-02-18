using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public NPCscript nPCscript;

    public GameObject talkText;
    public GameObject textBox;

    public Text theText;
    public Text theText2;
    public Text theText3;

    public bool HasMilkInInv;

    public bool HasGivenMilkToAbbis = false;

    public GameObject NPC;

    public int TimesTalkedToAbbis;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public Movement player;

    bool HasTalkedToAbbis = false;
    // Start is called before the first frame update
    void Start()
    {
        endAtLine = 7;

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

        Debug.Log(currentLine);
        theText.text = textLines[currentLine];

        var i = PlayerInventory.Hasitem(ItemList.Items.Milk);
        if (i != -1)
        {
            HasMilkInInv = true;
        }
        else
        {
            HasMilkInInv = false;
        }
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
        if (HasMilkInInv)
        {
            currentLine = 11;
            endAtLine = 15;
        }
        if (HasGivenMilkToAbbis)
        {
            TimesTalkedToAbbis = 10;
        }
        NPC.GetComponent<AudioSource>().Play();
        if (currentLine > endAtLine - 1 && TimesTalkedToAbbis == 0) //First time talking to Abbis
        {
            Debug.Log("1");
            if (!HasTalkedToAbbis)
            {
                PlayerInventory.AnyInvSlot((ItemList.Items)5);
            }
            TimesTalkedToAbbis++;
            player.CanMove = true;
            talkText.SetActive(true);
            textBox.SetActive(false);
            endAtLine = 10;
            currentLine = 9;
            HasTalkedToAbbis = true;
            PlayerScript.Gold += 10;
        }
        else if (currentLine > endAtLine - 1 && TimesTalkedToAbbis == 1 && !HasMilkInInv && !HasGivenMilkToAbbis) //Second time talking to abbis without the glass of milk
        {
            Debug.Log("2");
            player.CanMove = true;
            talkText.SetActive(true);
            textBox.SetActive(false);
            currentLine = 9;
            endAtLine = 10;
            /*if (TimesTalkedToAbbis != 1 && TimesTalkedToAbbis != 2)
            {
                TimesTalkedToAbbis = 2;
            }
            else
            {
                TimesTalkedToAbbis++;
            }*/
        }
        else if (currentLine > endAtLine - 1 && TimesTalkedToAbbis == 1 && HasMilkInInv) //Second time talking to abbis with milk
        {
            Debug.Log("3");
            player.CanMove = true;
            talkText.SetActive(true);
            textBox.SetActive(false);
            TimesTalkedToAbbis = 10;
            currentLine = 16;
            endAtLine = 69;
            HasGivenMilkToAbbis = true;
            var i = PlayerInventory.Hasitem(ItemList.Items.Milk);
            PlayerInventory.RemoveItem(i);
        }
        else if (TimesTalkedToAbbis == 10) //abbis dialogue completed
        {
            Debug.Log("4");
            player.CanMove = true;
            talkText.SetActive(true);
            textBox.SetActive(false);
        }
    }

    public void ActivateTextBox()
    {
        NPC.GetComponent<AudioSource>().Play();
        player.CanMove = false;
        textBox.SetActive(true);
    }
}
