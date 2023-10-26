using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] AudioSource buttonClickAudioSource;
    [SerializeField] GameObject howToPlayScreen;

    public void StartGame()
    {
        buttonClickAudioSource.Play();
        Invoke("startScene", 0.5f);
    }

    public void ChangeColor()
    {
        buttonClickAudioSource.Play();
        Invoke("chcScene", 0.5f);
    }

    public void HowToPlay()
    {
        buttonClickAudioSource.Play();
        howToPlayScreen.SetActive(true);
    }

    public void ExitHowToPlayScreen()
    {
        buttonClickAudioSource.Play();
        howToPlayScreen.SetActive(false);
    }
    
    private void startScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    private void chcScene()
    {
        SceneManager.LoadScene("ChangeHoleColorScene");
    }   

    
}
