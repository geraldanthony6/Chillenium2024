using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class InteractionZone : MonoBehaviour
{
    [SerializeField] private String RequiredItem;

    [SerializeField] private bool IsMessedWith;

    [SerializeField] private PlayerInventory Inventory;

    [SerializeField] private InventoryItem Item;

    [SerializeField] private SpriteRenderer Renderer;

    [SerializeField] private bool NeedsItem;

    [SerializeField] private ActionVisual ActionVisual;

    [SerializeField] public AudioClip EventAudio;

    [SerializeField] private Animator ReactAnimatior;

    [SerializeField] private bool IsLightFlicker;

    [SerializeField] private SpriteRenderer StoreSpriteRenderer;

    [SerializeField] private Light Light;

    [SerializeField] private GameObject NewInteractionVisual;

    [SerializeField] private GameObject TransformInteractionVisual;

    [SerializeField] private Sprite TransformedSprite;
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
        if (!IsMessedWith)
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
            if (ReactAnimatior)
            {
                ReactAnimatior.SetTrigger("DoAction");
            }
            
            if (NewInteractionVisual)
            {
                NewInteractionVisual.SetActive(true);
            }
            
            if (TransformInteractionVisual)
            {
                TransformInteractionVisual.GetComponent<SpriteRenderer>().sprite = TransformedSprite;
            }
        }
        else
        {
            IsMessedWith = true;
            Renderer.color = Color.red;
            ActionVisual.Activate();
            if (ReactAnimatior)
            {
                ReactAnimatior.SetTrigger("DoAction");
            }

            if (NewInteractionVisual)
            {
                NewInteractionVisual.SetActive(true);
            }

            if (TransformInteractionVisual)
            {
                TransformInteractionVisual.GetComponent<SpriteRenderer>().sprite = TransformedSprite;
            }

        if (IsLightFlicker && Inventory.LightIsOn)
            {
                StoreSpriteRenderer.color = Color.gray;
                Light.intensity = 0;
                Inventory.LightIsOn = false;
            }
            else if (IsLightFlicker && !Inventory.LightIsOn)
            {
                StoreSpriteRenderer.color = Color.white;
                Light.intensity = 1;
            }
        }

    }
    public bool GetIsMessedWith()
    {
        return IsMessedWith;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && NeedsItem)
        {
            Inventory.HelpTextBackground.gameObject.SetActive(true);
            Inventory.HelpText.text = "I think I need a " + RequiredItem + "!";
        }
        else if(other.CompareTag("Player") && !NeedsItem && !other.gameObject.GetComponent<PlayerInventory>().FirstEventHint)
        {
            Inventory.HelpTextBackground.gameObject.SetActive(true);
            Inventory.HelpText.text = "I think I need to press E..";
            other.gameObject.GetComponent<PlayerInventory>().FirstEventHint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.HelpTextBackground.gameObject.SetActive(false);
        }
    }
}
