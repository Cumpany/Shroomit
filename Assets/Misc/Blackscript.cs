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
        GoldObject.GetComponent<Text>().text = (player.Gold).ToString();
    }

    public void HealPotion()
    {
        if (player.Gold >= 10)
        {
            if (PlayerInventory.AnyInvSlot((ItemList.Items)4))
            {
                player.Gold -= 10;
            }
        }
    }
}
