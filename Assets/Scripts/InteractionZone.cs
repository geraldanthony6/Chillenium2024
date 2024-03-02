using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    [SerializeField] private String RequiredItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckIfCorrectItem(PlayerInventory inventory)
    {
        foreach (InventoryItem item in inventory.InventoryItems)
        {
            if (item.ItemName == RequiredItem)
            {
                inventory.RemoveItemFromInventory(item);
                return true;
            }
        }

        return false;
    }
}
