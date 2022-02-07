using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public ItemList.Items[,] Inv = new ItemList.Items[3, 9];
    public ItemList.Items Cursor = new ItemList.Items();
    // Start is called before the first frame update
    public void AddItem(int x, int y, ItemList.Items i)
    {
        if (IsSlotFree(x,y))
        {
            Inv[x,y] = i;
        }
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
