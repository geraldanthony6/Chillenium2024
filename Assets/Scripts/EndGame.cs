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

    [SerializeField] private Image RankImage;

    [SerializeField] private Sprite DRankSprite;
    
    [SerializeField] private Sprite CRankSprite;
    
    [SerializeField] private Sprite BRankSprite;
    
    [SerializeField] private Sprite ARankSprite;
    
    [SerializeField] private Sprite SRankSprite;
    
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
        PlayerChaos.GameOver = true;
        Time.timeScale = 0;
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
        
        switch (PlayerChaos.GetChaosEventsDone())
            {
                case 0:
                    RankImage.sprite = DRankSprite;
                    break;
                case 1:
                    RankImage.sprite = DRankSprite;
                    break;
                case 2:
                    RankImage.sprite = DRankSprite;
                    break;
                case 3:
                    RankImage.sprite = DRankSprite;
                    break;
                case 4:
                    RankImage.sprite = CRankSprite;
                    break;
                case 5:
                    RankImage.sprite = CRankSprite;
                    break;
                case 6:
                    RankImage.sprite = CRankSprite;
                    break;
                case 7:
                    RankImage.sprite = CRankSprite;
                    break;
                case 8:
                    RankImage.sprite = BRankSprite;
                    break;
                case 9:
                    RankImage.sprite = BRankSprite;
                    break;
                case 10:
                    RankImage.sprite = BRankSprite;
                    break;
                case 11:
                    RankImage.sprite = BRankSprite;
                    break;
                case 12:
                    RankImage.sprite = ARankSprite;
                    break;
                case 13:
                    RankImage.sprite = ARankSprite;
                    break;
                case 14:
                    RankImage.sprite = ARankSprite;
                    break;
                case 15:
                    RankImage.sprite = ARankSprite;
                    break;
                case 16:
                    RankImage.sprite = SRankSprite;
                    break;
            }
        
        ScoreText.text = "You caused " + PlayerChaos.GetChaosEventsDone() + "/" + 16 + " chaos events!";
    }
}
