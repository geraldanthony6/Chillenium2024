using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [field: SerializeField]
    private Image spriteRenderer;
    [field: SerializeField]
    private Sprite replacementSprite;
    public void PlayGame()
    {
        //spriteRenderer.sprite = replacementSprite;
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Tutorial()
    {
        //spriteRenderer.sprite = replacementSprite;
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        //spriteRenderer.sprite = replacementSprite;
        SceneManager.LoadScene("MainMenu");
    }
}

