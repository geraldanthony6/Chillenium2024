using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerChaos : MonoBehaviour
{
    [SerializeField] private float ChaosAmount;

    [SerializeField] private TextMeshProUGUI ChaosAmountText;

    [SerializeField] private float MaxChaos;

    [SerializeField] private float CurrentChaos;
    
    [SerializeField] private Image ChaosBar;

    [SerializeField] private bool IsNearIncident;

    [SerializeField] private PlayerInventory PlayerInventory;

    [SerializeField] private InteractionZone CurrentInteractionZone;

    [SerializeField] private List<Shopper> ShoppersList;

    [SerializeField] private List<PoliceMovement> PoliceList;
    // Start is called before the first frame update
    void Start()
    {
        ChaosBar.fillAmount = 0.0f;
        MaxChaos = 16.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsNearIncident)
        {
            CurrentChaos += 1.0f;
            ChaosBar.fillAmount = CurrentChaos / MaxChaos;
            ChaosAmountText.text = "Chaos Events Caused: " + CurrentChaos + "/" + MaxChaos;
            CurrentInteractionZone.UpdateInteractionZone();
        }

        if (CurrentChaos > 0.0f)
        {
            ChaosBar.fillAmount = CurrentChaos / MaxChaos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ChaosIncident"))
        {
            CurrentInteractionZone = other.GetComponent<InteractionZone>();
            IsNearIncident = CurrentInteractionZone.CheckIfCorrectItem(PlayerInventory);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ChaosIncident"))
        {
            IsNearIncident = false;
        }
        
        if(other.CompareTag(""))
    }

    public float GetChaosAmount()
    {
        return ChaosAmount;
    }
}
