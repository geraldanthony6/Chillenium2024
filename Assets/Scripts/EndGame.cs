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

    public void CalculateResults(int NumForOutcome)
    {
        EndGameScreen.gameObject.SetActive(true);
        switch (NumForOutcome)
        {
            case 1:
                GameOverText.text = "You couldn't hang in there and escape...";
                break;
            case 2:
                GameOverText.text = "Those cops couldn't hang with you! You got out!";
                break;
            case 3:
                GameOverText.text = "You ran out of chaos energy... L delinquent";
                break;
        }
        
        ScoreText.text = "You caused " + PlayerChaos.GetChaosEventsDone() + "/" + 16 + " chaos events!";
    }
}
