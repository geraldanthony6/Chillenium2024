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

    [SerializeField] private bool EndEvent;

    [SerializeField] private AudioSource AudioSource;

    [SerializeField] private int ChaosEventsDone;

    [SerializeField] public bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        ChaosBar.fillAmount = 1.0f;
        MaxChaos = 16.0f;
        CurrentChaos = MaxChaos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsNearIncident && !EndEvent)
        {
            EndEvent = true;
            CurrentChaos += 1.5f;
            ChaosEventsDone += 1;
            ChaosBar.fillAmount = CurrentChaos / MaxChaos;
            ChaosAmountText.text = "Chaos Events Caused " + ChaosEventsDone + "/" + MaxChaos;
            CurrentInteractionZone.UpdateInteractionZone();

            AudioSource.clip = CurrentInteractionZone.EventAudio;
            AudioSource.Play();

            if (CurrentChaos == 3.0f)
            {
                UpdateStoreSpeed(2.0f);
            }

            if (CurrentChaos == 10.0f)
            {
                UpdateStoreSpeed(2.0f);
            }

            if (CurrentChaos == 13.0f)
            {
                UpdateStoreSpeed(2.0f);
            }
        }

        if (CurrentChaos > 0.0f)
        {
            CurrentChaos -= Time.deltaTime * 0.5f;
            ChaosBar.fillAmount = CurrentChaos / MaxChaos;
        }

        if (CurrentChaos <= 0.0f && !GameOver)
        {
            GameOver = true;
            ChaosEventsDone = (int)(ChaosEventsDone * 0.75);
            Debug.Log(ChaosEventsDone);
            EndGame.CalculateResults(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ChaosIncident") && !EndEvent)
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
            EndEvent = false;
        }

        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cop") && !GameOver)
        {
            GameOver = true;
            ChaosEventsDone = ChaosEventsDone / 2;
            EndGame.CalculateResults(1);
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

    public int GetChaosEventsDone()
    {
        return ChaosEventsDone;
    }
}
