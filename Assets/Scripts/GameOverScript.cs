using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{    

    [SerializeField] TMP_Text holeScoreText;
    [SerializeField] AudioSource buttonClickAudio;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        holeScoreText.text = "Your Score: " + score.ToString();
    }

    public void PlayAgain()
    {
        buttonClickAudio.Play();
        Invoke("playAgainScene", 0.5f);
    }

    public void MainMenu()
    {
        buttonClickAudio.Play();
        Invoke("mainMenuScene", 0.5f);
    }

    private void playAgainScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    private void mainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
