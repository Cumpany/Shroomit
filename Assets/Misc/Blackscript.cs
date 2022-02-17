using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackscript : MonoBehaviour
{
    public PlayerScript player;
    public GameObject heal;

    [SerializeField] private GameObject GoldObject;

    void Start()
    {
        
    }
    // Start is called before the first frame update
    void Update()
    {
        GoldObject.GetComponent<Text>().text = (PlayerScript.Gold).ToString();
    }

    public void HealPotion()
    {
        var p = new PlayerScript();
        if (PlayerScript.Gold >= 10)
        {
            if (PlayerInventory.AnyInvSlot((ItemList.Items)4))
            {
                PlayerScript.Gold -= 10;
                Debug.Log("player bought health potion for 10 gold");
            }
        }
    }

    public void Sword4()
    {
        if (PlayerScript.Gold >= 25)
        {
            if (PlayerInventory.AnyInvSlot((ItemList.Items)8))
            {
                PlayerScript.Gold -= 25;
                Debug.Log("player bought Sword4 for 25 gold");
            }
        }
    }

    public void Sword2()
    {
        if (PlayerScript.Gold >= 10)
        {
            if (PlayerInventory.AnyInvSlot((ItemList.Items)6))
            {
                PlayerScript.Gold -= 10;
                Debug.Log("player bought Sword2 for 10 gold");
            }
        }
    }
}
