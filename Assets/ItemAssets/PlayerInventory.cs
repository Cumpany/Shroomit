using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public static ItemList.Items[] Inv = new ItemList.Items[9];
    public static ItemList.Items Cursor = new ItemList.Items();
    [SerializeField] private GameObject CursorObject;
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject[] InvSlots = new GameObject[9];
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
            DrawInv();
        }
        if (Cursor != 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Pressed Q");
                DropCursor();
            }
            CursorObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            CursorObject.transform.position = new Vector3(0,1,0);
        }
    }
    void Start()
    {
        Cursor = 0;
        DrawInv();
        Inventory.SetActive(false);
    }
    void DrawInv()
    {
        for (var x = 0; x < 9; x++)
        {
            InvSlots[x].transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(Inv[x].ToString());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject item = col.gameObject;
        //Debug.Log(col.gameObject.name);
        if (item.tag == "DroppedItem")
        {
            ItemList.Items i = (ItemList.Items) Convert.ToInt32(item.transform.position.z);
            if (AnyInvSlot(i))
            {
                Destroy(item);
                DrawInv();
            }
            else Debug.LogWarning("inventory full");
        }
    }
    public void ClickInvSlot(int slot)
    {
        if (Inv[slot] == 0)
        {
            CursorToInv(slot);
        }
        else if (Cursor == 0)
        {
            InvToCursor(slot);
        }
        else
        {
            Debug.Log("Can't");
            return;
        }
        CursorObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Cursor.ToString());
    }
    [SerializeField] private GameObject ItemPreset;
    public void DropCursor()
    {
        var i = Instantiate(ItemPreset);
        i.transform.position = CursorObject.transform.position;
        i.transform.position = new Vector3(i.transform.position.x,i.transform.position.y,(int)Cursor);
        i.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Cursor.ToString());
        Cursor = 0;
    }
    public static bool AnyInvSlot(ItemList.Items i)
    {
        for (var x = 0; x < 9; x++)
        {
            if (AddItem(x,i))
            {
                Debug.Log($"Added {i} to inventory at {x}");
                return true;
            }
        }
        Debug.LogWarning($"Failed to add {i} to inventory");
        return false;
    }
    public static bool AddItem(int x, ItemList.Items i)
    {
        if (IsSlotFree(x))
        {
            Inv[x] = i;
            return true;
        }
        return false;
    }
    public void CursorToInv(int x)
    {
        if (Cursor != 0 && Inv[x] == 0)
        {
            AddItem(x,Cursor);
            Cursor = 0;
            DrawInv();
        }
    }
    public void InvToCursor(int x)
    {
        if (Cursor == 0 && Inv[x] != 0)
        {
            Cursor = Inv[x];
            Inv[x] = 0;
            Debug.Log("added "+Cursor+" to cursor?");
            DrawInv();
            return;
        }
        Debug.Log("Cursor full?");
    }
    public static bool IsSlotFree(int x)
    {
        if (Inv[x] == 0)
        {
            return true;
        }
        else return false;
    }
    public void ClearInv()
    {
        for (var x = 0; x < 9; x++)
        {
            Inv[x] = 0;
        }
        Cursor = 0;
    }
}
