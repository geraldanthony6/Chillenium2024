using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    [SerializeField] private String RequiredItem;

    [SerializeField] private bool IsMessedWith;

    [SerializeField] private PlayerInventory Inventory;

    [SerializeField] private InventoryItem Item;
    // Start is called before the first frame update
    void Start()
    {
        Inventory = FindObjectOfType<PlayerInventory>();
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
                Item = item;
                return true;
            }
        }

        return false;
    }

    public void UpdateInteractionZone()
    {
        Inventory.RemoveItemFromInventory(Item);
        IsMessedWith = true;
    }
    public bool GetIsMessedWith()
    {
        return IsMessedWith;
    }
}
