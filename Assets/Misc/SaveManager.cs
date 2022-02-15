using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Newtonsoft.Json;

public class PlayerSave
{
    public float XPos {get; set;}
    public float YPos {get; set;}
    public float HP {get; set;}
    public ItemList.Items[] Inv {get; set;} = new ItemList.Items[9];
    public ItemList.Items Cursor {get; set;}
}
public class EnemySave
{
    public float XPos {get; set;}
    public float YPos {get; set;}
    public float HP {get; set;}
}
public class ItemSave
{
    public float XPos {get; set;}
    public float YPos {get; set;}
    public ItemList.Items Item {get; set;}
}
public class SaveManager : MonoBehaviour
{
    public void Save()
    {
        var i = new PlayerInventory();
        var player = new PlayerSave 
        {
            XPos = GameObject.FindGameObjectWithTag("Player").transform.position.x,
            YPos = GameObject.FindGameObjectWithTag("Player").transform.position.y,
            HP = PlayerScript.health,
            Inv = i.Inv,
            Cursor = i.Cursor
        };
        // int j;
        List<string> EnemyList = new List<string>();
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            var k = new EnemyScript();
            var Enemy = new EnemySave 
            {
                XPos = item.transform.position.x,
                YPos = item.transform.position.y,
                HP = item.GetComponent<EnemyScript>().enemyHP
            };
            EnemyList.Add(JsonConvert.SerializeObject(Enemy));
        }

    }
    public void Load()
    {

    }
    public void Write()
    {

    }
    public void Read()
    {

    }
}
