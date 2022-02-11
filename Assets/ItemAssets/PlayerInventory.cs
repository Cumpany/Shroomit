using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public ItemList.Items[] Inv = new ItemList.Items[9];
    private ItemList.Items Cursor = new ItemList.Items();
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
            CursorObject.transform.position = Input.mousePosition;
        }
        else
        {
            CursorObject.transform.position = new Vector3(0,3,0);
        }
    }
    void Start()
    {
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
        InvToCursor(slot);
        CursorObject.transform.GetChild(1).transform.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Cursor.ToString());
    }
    public bool AnyInvSlot(ItemList.Items i)
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
    public bool AddItem(int x, ItemList.Items i)
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
        if (Cursor != 0 && Inv[x] != 0)
        {
            AddItem(x,Cursor);
            Cursor = 0;
        }
    }
    public void InvToCursor(int x)
    {
        if (Cursor != 0 && Inv[x] != 0)
        {
            Cursor = Inv[x];
            Inv[x] = 0;
        }
    }
    public bool IsSlotFree(int x)
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
    }
}
