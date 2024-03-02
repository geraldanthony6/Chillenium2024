using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> InventoryItems;

    [SerializeField] private Image[] InventorySpots;

    [SerializeField] private int MaxInventoryItems;
    [SerializeField] private int CurrentInventoryIndex;
    // Start is called before the first frame update
    void Start()
    {
        MaxInventoryItems = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddItemToInventory(InventoryItem newItem)
    {
        if (CurrentInventoryIndex < MaxInventoryItems)
        {
            InventoryItems.Add(newItem);
            InventorySpots[CurrentInventoryIndex].sprite = newItem.ItemSprite;
            CurrentInventoryIndex++;
        }
        else
        {
            Debug.Log("Inventory Full");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InventoryItem"))
        {
            InventoryItem newItem = other.GetComponent<InventoryItem>();
            AddItemToInventory(newItem);
        }
    }
}
