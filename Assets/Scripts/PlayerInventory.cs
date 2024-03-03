using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public List<InventoryItem> InventoryItems;

    [SerializeField] private Image[] InventorySpots;

    [SerializeField] private Sprite EmptySprite;
    
    [SerializeField] private int MaxInventoryItems;
    [SerializeField] private int CurrentInventoryIndex;

    [SerializeField] private bool NearItem;

    [SerializeField] private InventoryItem CurrentItemNear;

    [SerializeField] public Image HelpTextBackground;
    [SerializeField] public TextMeshProUGUI HelpText;

    [SerializeField] public bool FirstEventHint;
    // Start is called before the first frame update
    void Start()
    {
        MaxInventoryItems = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && NearItem)
        {
            PickUpObject(CurrentItemNear);
        }
    }

    private void AddItemToInventory(InventoryItem newItem)
    {
        if (CurrentInventoryIndex < MaxInventoryItems)
        {
            InventoryItems.Add(newItem);
            newItem.ItemIndex = CurrentInventoryIndex;
            InventorySpots[CurrentInventoryIndex].sprite = newItem.ItemSprite;
            CurrentInventoryIndex++;
        }
        else
        {
            Debug.Log("Inventory Full");
        }

    }

    public void RemoveItemFromInventory(InventoryItem item)
    {
        InventoryItems.Remove(item);
        InventorySpots[item.ItemIndex].sprite = EmptySprite;
        CurrentInventoryIndex--;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InventoryItem"))
        {
            HelpTextBackground.gameObject.SetActive(true);
            HelpText.text = "I think I need to press Q...";
            CurrentItemNear = other.GetComponent<InventoryItem>();
            NearItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InventoryItem"))
        {
            HelpTextBackground.gameObject.SetActive(false);
            CurrentItemNear = null;
            NearItem = false;
        }
    }


    private void PickUpObject(InventoryItem newItem)
    {
        AddItemToInventory(newItem);
        NearItem = false;
        Destroy(newItem.gameObject);
    }
}
