using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootBag : MonoBehaviour
{

    public GameObject droppedItemPrefab;
    public List<corazones> lootList = new List<corazones>();
   
    corazones GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101); // de 1 a 100
        List<corazones> possibleItems = new List<corazones>();
        foreach (corazones item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            corazones droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("no dropea nada");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        corazones droppedItem = GetDroppedItem();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
        }
    }
}
