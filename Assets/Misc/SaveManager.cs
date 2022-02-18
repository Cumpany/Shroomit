using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
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
    public float Index {get; set;}
    public float XPos {get; set;}
    public float YPos {get; set;}
    public float HP {get; set;}
}
public class ItemSave
{
    public float Index {get; set;}
    public float XPos {get; set;}
    public float YPos {get; set;}
    public ItemList.Items Item {get; set;}
}
public class SaveIndex
{
    public int Enemies {get; set;}
    public int Items {get; set;}
}
public class SaveOther
{
    public bool BossBarrier {get; set;}
    public float GameTime {get; set;}
}
public class SaveBoss
{
    public float XPos {get; set;}
    public float YPos {get; set;}
    public float BossHP {get; set;}
}
public class SaveManager : MonoBehaviour
{
    public static bool SaveGame;
    public void ToggleSave(bool b)
    {
        SaveGame = b;
    }
    public static void Save()
    {
        if (!SaveGame)
        {
            Debug.Log("Stopped game from saving");
            return;
        }

        var Player = new PlayerSave 
        {
            XPos = GameObject.FindGameObjectWithTag("Player").transform.position.x,
            YPos = GameObject.FindGameObjectWithTag("Player").transform.position.y,
            HP = PlayerScript.health,
            Inv = PlayerInventory.Inv,
            Cursor = PlayerInventory.Cursor
        };
        File.WriteAllText("Player.sav",JsonConvert.SerializeObject(Player));
        

        int j = 0;
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            var Enemy = new EnemySave 
            {
                Index = j,
                XPos = item.transform.position.x,
                YPos = item.transform.position.y,
                HP = item.GetComponent<EnemyScript>().enemyHP
            };
            File.WriteAllText($"Enemy{j}.sav",JsonConvert.SerializeObject(Enemy));
            j++;
        }


        int h = 0;
        List<string> ItemList = new List<string>();
        foreach (var item in GameObject.FindGameObjectsWithTag("DroppedItem"))
        {
            var Item = new ItemSave 
            {
                Index = h,
                XPos = item.transform.position.x,
                YPos = item.transform.position.y,
                Item = (ItemList.Items)item.transform.position.z
            };
            File.WriteAllText($"Item{h}.sav",JsonConvert.SerializeObject(Item));
            h++;
        }
        

        var SIndex = new SaveIndex
        {
            Enemies = j,
            Items = h
        };
        File.WriteAllText("Index.sav",JsonConvert.SerializeObject(SIndex));


        var OtherSave = new SaveOther
        {
            BossBarrier = BossBarrier.Bar.activeSelf,
            GameTime = StaticScript.Timer
        };
        File.WriteAllText("Other.sav",JsonConvert.SerializeObject(OtherSave));

        var bos = GameObject.Find("boss");
        var BossSave = new SaveBoss
        {
            XPos = bos.transform.position.x,
            YPos = bos.transform.position.y,
            BossHP = boss.enemyHP
        };
        File.WriteAllText("Boss.sav",JsonConvert.SerializeObject(BossSave));
        
    }
    private GameObject EnemyPrefab;
    private GameObject ItemPrefab;
    void Awake()
    {
        EnemyPrefab = Resources.Load("enemy", typeof(GameObject)) as GameObject;
        ItemPrefab = Resources.Load("ItemPrefab", typeof(GameObject)) as GameObject;
    }
    public static void StaticLoad()
    {
        var l = Camera.main.gameObject.AddComponent<SaveManager>();
        l.Load();
    }
    public void Load()
    {
        if (!SaveGame)
        {
            DeleteSave();
            Debug.Log("stopped game from loading save and deleted save");
            return;
        }
        var eDeletion = GameObject.FindGameObjectsWithTag("Enemy");
        for (var i = 0; i < eDeletion.Length; i++)
        {
            Destroy(eDeletion[i]);
        }
        var iDeletion = GameObject.FindGameObjectsWithTag("DroppedItem");
        for (var i = 0; i < iDeletion.Length; i++)
        {
            Destroy(iDeletion[i]);
        }


        var o = JsonConvert.DeserializeObject<PlayerSave>(File.ReadAllText("Player.sav"));
        PlayerInventory.Cursor = o.Cursor;
        PlayerInventory.Inv = o.Inv;
        PlayerScript.health = o.HP;
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(o.XPos,o.YPos,1);


        int Enemies = JsonConvert.DeserializeObject<SaveIndex>(File.ReadAllText("Index.sav")).Enemies;
        int Items = JsonConvert.DeserializeObject<SaveIndex>(File.ReadAllText("Index.sav")).Items;
        if (Enemies > 0)
        {
            for (var i = 0; i < Enemies; i++)
            {
                var h = JsonConvert.DeserializeObject<EnemySave>(File.ReadAllText($"Enemy{i}.sav"));
                var k = new Vector3(h.XPos,h.YPos,0);
                var j = Instantiate(EnemyPrefab);
                j.transform.position = k;
                j.GetComponent<EnemyScript>().enemyHP = h.HP;
            }
        }

        if (Items > 0)
        {
            for (var i = 0; i < Items; i++)
            {
                var h = JsonConvert.DeserializeObject<ItemSave>(File.ReadAllText($"Item{i}.sav"));
                var k = new Vector3(h.XPos,h.YPos,(int)h.Item);
                var j = Instantiate(ItemPrefab);
                j.transform.position = k;
                j.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = 
                Resources.Load<Sprite>(h.Item.ToString());
            }
        }
        var g = JsonConvert.DeserializeObject<SaveOther>(File.ReadAllText("Other.sav"));
        GameObject.Find("Bossbarrier").SetActive(g.BossBarrier);
        StaticScript.Timer = g.GameTime;
        var u = JsonConvert.DeserializeObject<SaveBoss>(File.ReadAllText("Boss.sav"));
        boss.enemyHP = u.BossHP;
        var bos = GameObject.Find("boss");
        bos.transform.position = new Vector3(u.XPos,u.YPos,0);

    }
    public static bool IsSaveFile()
    {
        var i = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.sav");
        if (i.Length != 0)
        {
            Debug.Log("save file exists");
            return true;
        }
        Debug.Log("save file does not exist");
        return false;
    }
    public static void DeleteSave()
    {
        var i = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.sav");
        for (var j = 0; j < i.Length; j++)
        {
            Debug.Log(i[j]);
            File.Delete(i[j]);
        }
        Debug.Log("deleted " + i.Length + "files");
        boss.enemyHP = boss.maxEnemyHP;
        PlayerScript.health = PlayerScript.maxHealth;
        PlayerInventory.ClearInv();
    }
}