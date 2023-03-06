using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject lootObj;
    public string lootName;
    public int dropChance;

    public Loot(GameObject lootObj, string lootName, int dropChance)
    {
        this.lootObj = lootObj;
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
