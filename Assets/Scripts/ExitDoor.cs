using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private PlayerChaos PlayerChaos;

    [SerializeField] private EndGame EndGame;

    [SerializeField] private bool IsReadyToLeave;

    [SerializeField] private AudioSource DoorSource;

    [SerializeField] private AudioClip DoorClose;
    // Start is called before the first frame update
    void Start()
    {
        IsReadyToLeave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsReadyToLeave)
        {
            DoorSource.clip = DoorClose;
            DoorSource.Play();
            EndGame.CalculateResults(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IsReadyToLeave = true;
            //EndGame.CalculateResults(2);
        }
    }
    
    
}
