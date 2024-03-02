using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Image EndGameScreen;
    [SerializeField] private TextMeshProUGUI GameOverText;

    [SerializeField] private TextMeshProUGUI ScoreText;

    [SerializeField] private PlayerChaos PlayerChaos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateResults(bool WasCaught)
    {
        EndGameScreen.gameObject.SetActive(true);
        if (WasCaught)
        {
            GameOverText.text = "You couldn't hang in there and escape...";
        }
        else
        {
            GameOverText.text = "Those cops couldn't hang with you! You got out!";
        }
        ScoreText.text = "You caused " + PlayerChaos.GetChaosAmount() + "/" + 16;
    }
}
