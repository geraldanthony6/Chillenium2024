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

    [SerializeField] public List<PoliceMovement> PoliceList;

    [SerializeField] private EndGame EndGame;
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
            ChaosAmountText.text = "Chaos Events Caused " + CurrentChaos + "/" + MaxChaos;
            CurrentInteractionZone.UpdateInteractionZone();

            if (CurrentChaos == 3.0f)
            {
                UpdateStoreSpeed(2.0f);
            }

            if (CurrentChaos == 10.0f)
            {
                UpdateStoreSpeed(4.0f);
            }

            if (CurrentChaos == 13.0f)
            {
                UpdateStoreSpeed(6.0f);
            }
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

        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cop"))
        {
            EndGame.CalculateResults(true);
        }
    }

    private void UpdateStoreSpeed(float AddValue)
    {
        foreach (PoliceMovement Cop in PoliceList)
        {
            Cop.CopSpeed += AddValue;
        }
    }

    public float GetChaosAmount()
    {
        return CurrentChaos;
    }
}
