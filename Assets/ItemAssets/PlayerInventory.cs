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
    [SerializeField] private GameObject Inventory;
    [SerializeField]private GameObject[] InvSlots = new GameObject[9];
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
            DrawInv();
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
            switch ((int)Inv[x])
            {
                case 0:
                // Debug.Log($"case 0 at {x}");
                InvSlots[x].transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("empty");
                    break;
                case 1:
                // Debug.Log($"case 1 at {x}");
                InvSlots[x].transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("apple");
                    break;
                case 2:
                // Debug.Log($"case 2 at {x}");
                InvSlots[x].transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("banana");
                    break;
                case 3:
                // Debug.Log($"case 3 at {x}");
                InvSlots[x].transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("orange");
                    break;
                default:
                Debug.LogError($"Invalid Item ID at {x}");
                InvSlots[x].transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("error");
                    break;
            }
        }
    }

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
                DrawInv();
            }
            else Debug.LogWarning("inventory full");
        }
    }
    public bool AnyInvSlot(ItemList.Items i)
    {
        for (var x = 0; x < 3; x++)
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
