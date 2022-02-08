using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public ItemList.Items[,] Inv = new ItemList.Items[3, 9];
    private ItemList.Items Cursor = new ItemList.Items();

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject item = col.gameObject;
        //Debug.Log(col.gameObject.name);
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
            for (var y = 0; y < 9; y++)
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
