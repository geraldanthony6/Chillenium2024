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

    [SerializeField] private SpriteRenderer Renderer;

    [SerializeField] private bool NeedsItem;

    [SerializeField] private ActionVisual ActionVisual;
    // Start is called before the first frame update
    void Start()
    {
        Inventory = FindObjectOfType<PlayerInventory>();
        Renderer = GetComponent<SpriteRenderer>();
        ActionVisual = GetComponent<ActionVisual>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckIfCorrectItem(PlayerInventory inventory)
    {
        if (NeedsItem)
        {
            foreach (InventoryItem item in inventory.InventoryItems)
            {
                if (item.ItemName == RequiredItem)
                {
                    Item = item;
                    return true;
                }
            }
        }
        else
        {
            return true;
        }


        return false;
    }

    public void UpdateInteractionZone()
    {
        if (NeedsItem)
        {
            Inventory.RemoveItemFromInventory(Item);
            IsMessedWith = true;
            Renderer.color = Color.red;
            ActionVisual.Activate();
        }
        else
        {
            IsMessedWith = true;
            Renderer.color = Color.red;
            ActionVisual.Activate();
        }

    }
    public bool GetIsMessedWith()
    {
        return IsMessedWith;
    }
}
