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
    // Start is called before the first frame update
    void Start()
    {
        ChaosBar.fillAmount = 0.0f;
        MaxChaos = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsNearIncident)
        {
            CurrentChaos += 20.0f;
            ChaosBar.fillAmount = CurrentChaos / MaxChaos;
            ChaosAmountText.text = "Chaos Score: " + CurrentChaos;
        }

        if (CurrentChaos > 0.0f)
        {
            CurrentChaos -= Time.deltaTime;
            ChaosBar.fillAmount = CurrentChaos / MaxChaos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ChaosIncident"))
        {
            InteractionZone curInteractionZone = other.GetComponent<InteractionZone>();
            IsNearIncident = curInteractionZone.CheckIfCorrectItem(PlayerInventory);
            //IsNearIncident = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ChaosIncident"))
        {
            IsNearIncident = false;
        }
    }

    public float GetChaosAmount()
    {
        return ChaosAmount;
    }
}
