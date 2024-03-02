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
    
    [SerializeField] private Slider ChaosBar;

    [SerializeField] private bool IsNearIncident;

    [SerializeField] private PlayerInventory PlayerInventory;
    // Start is called before the first frame update
    void Start()
    {
        MaxChaos = 100.0f;
        CurrentChaos = 0.0f;
        ChaosBar.maxValue = MaxChaos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsNearIncident)
        {
            CurrentChaos += 25.0f;
            ChaosBar.value += 25.0f;
        }

        if (CurrentChaos > 0.0f)
        {
            CurrentChaos -= Time.deltaTime;
            ChaosBar.value -= Time.deltaTime;
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
}
