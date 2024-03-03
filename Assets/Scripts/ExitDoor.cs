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

    [SerializeField] private float AnimationTimer;

    [SerializeField] private SpriteRenderer Renderer;

    [SerializeField] private Sprite DoorOne;
    
    [SerializeField] private Sprite DoorTwo;
    
    [SerializeField] private Sprite DoorThree;

    [SerializeField] private Sprite DoorFour;

    [SerializeField] private PlayerInventory Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        IsReadyToLeave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsReadyToLeave)
        {
            DoorSource.volume = 1;
            DoorSource.clip = DoorClose;
            DoorSource.Play();
            EndGame.CalculateResults(2);
        }

        if (!IsReadyToLeave)
        {
            Renderer.sprite = DoorOne;
            AnimationTimer = 0.0f;
        }

        if (AnimationTimer > 0.0f)
        {
            AnimationTimer -= Time.deltaTime;
        }

        if (AnimationTimer > 0.75f && AnimationTimer < 1.0f)
        {
            Renderer.sprite = DoorOne;
        } else if (AnimationTimer > 0.5f && AnimationTimer < 0.75f)
        {
            Renderer.sprite = DoorTwo;
        } else if (AnimationTimer > 0.25f && AnimationTimer < 0.5f)
        {
            Renderer.sprite = DoorThree;
        }
        else if (AnimationTimer > 0.0f && AnimationTimer < 0.25f)
        {
            Renderer.sprite = DoorFour;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.HelpTextBackground.gameObject.SetActive(true);
            Inventory.HelpText.text = "I can leave with E I think...";
            IsReadyToLeave = true;
            AnimationTimer = 1.0f;
            //EndGame.CalculateResults(2);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.HelpTextBackground.gameObject.SetActive(false);
            IsReadyToLeave = false;
        }
    }
}
