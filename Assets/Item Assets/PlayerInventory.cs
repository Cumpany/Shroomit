using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public ItemList.Items[,] Inv = new ItemList.Items[3, 3];
    private ItemList.Items Cursor = new ItemList.Items();
    [SerializeField] private GameObject Inventory;
    public Sprite Error, Apple, Banana, Orange;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
        DrawInv();
    }
    void DrawInv()
    {
        for (var x = 0; x < 3; x++)
        {
            for (var y = 0; y < 3; y++)
            {
                var k = transform.Find($"{x},{y}").transform.GetComponent<Image>().sprite;
                // var i = transform.GetChild((x+1*y+1)-1).transform.GetComponent<Image>().sprite;
                // ItemList.Items j = (ItemList.Items)(x+1*y+1)-1;
                switch ((x+1*y+1)-1)
                {
                    case 0:
                        break;
                    case 1:
                    k = Apple;
                        break;
                    case 2:
                    k = Banana;
                        break;
                    case 3:
                    k = Orange;
                        break;
                    default:
                    k = Error;
                        break;
                }
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        GameObject item = col.gameObject;
        if (item.tag == "DroppedItem")
        {
            ItemList.Items i = (ItemList.Items) Convert.ToInt32(item.name);
            if (AnyInvSlot(i))
            {
                Destroy(item);
            }
            else Debug.LogWarning("inventory full");
        }
    }
    public bool AnyInvSlot(ItemList.Items i)
    {
        for (var x = 0; x < 3; x++)
        {
            for (var y = 0; y < 3; y++)
            {
                if (AddItem(x,y,i))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool AddItem(int x, int y, ItemList.Items i)
    {
        if (IsSlotFree(x,y))
        {
            Inv[x,y] = i;
            return true;
        }
        return false;
    }
    public void CursorToInv(int x,int y)
    {
        if (Cursor != 0 && Inv[x,y] != 0)
        {
            AddItem(x,y,Cursor);
            Cursor = 0;
        }
    }
    public void InvToCursor(int x, int y)
    {
        if (Cursor != 0 && Inv[x,y] != 0)
        {
            Cursor = Inv[x,y];
            Inv[x,y] = 0;
        }
    }
    public bool IsSlotFree(int x, int y)
    {
        if (Inv[x,y] == 0)
        {
            return true;
        }
        else return false;
    }
    public void ClearInv()
    {
        for (var y = 0; y < 3; y++)
        {
            for (var x = 0; x < 9; x++)
            {
                Inv[x,y] = 0;
            }
        }
    }
}
