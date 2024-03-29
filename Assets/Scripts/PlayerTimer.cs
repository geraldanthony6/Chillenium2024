using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTimer : MonoBehaviour
{
    [SerializeField] private float GameTimer;

    [SerializeField] private TextMeshProUGUI GameTimerText;

    [SerializeField] private bool IsGameRunning;

    [SerializeField] private EndGame EndGame;
    // Start is called before the first frame update
    void Start()
    {
        GameTimer = 60.0f;
        IsGameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameTimer > 0 && IsGameRunning)
        {
            GameTimer -= Time.deltaTime;
            DisplayTime(GameTimer);
        }
        else if(GameTimer < 0 && IsGameRunning)
        {
            EndGame.CalculateResults(3);
            IsGameRunning = false;
        }


    }

    private void DisplayTime(float Time)
    {
        Time += 1;
        
        float minutes = Mathf.FloorToInt(Time / 60);
        float seconds = Mathf.FloorToInt(Time % 60);
        GameTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
