using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopperBrain : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ShopperRenderer;

    [SerializeField] private Material AngryMaterial;

    [SerializeField] private Shopper ShopperMovement;

    [SerializeField] private bool IsPissed;
    // Start is called before the first frame update
    void Start()
    {
        ShopperMovement = GetComponent<Shopper>();
        ShopperRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ChaosIncident") && other.GetComponent<InteractionZone>().GetIsMessedWith())
        {
            ShopperRenderer.color = Color.red;
            IsPissed = true;
        }
    }

    public bool GetIsPissed()
    {
        return IsPissed;
    }
}
