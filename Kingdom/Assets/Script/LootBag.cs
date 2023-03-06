using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
   public List<Loot> lootList = new List<Loot>();
   
   Loot getDroppedItem()
    {
        // select drop by chance
        int randomNumber = Random.Range(1, 101);
        List<Loot>possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if(randomNumber<= item.dropChance)
            {
                possibleItems.Add(item);
                //here i could ask to drop more items at the same time but i don't know how
            }
            //this make sure they drop only one item at the time
            if(possibleItems.Count >0 )
            {
                Loot droppedItem = possibleItems[Random.Range(0,possibleItems.Count)];
                return droppedItem;
            }
            
        }
        return null;
    }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = getDroppedItem();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItem.lootObj, spawnPosition, Quaternion.identity);
        }

    }
}
