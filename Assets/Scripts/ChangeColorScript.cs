using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColorScript : MonoBehaviour
{
    public static ChangeColorScript changeColorInstance;

    [SerializeField] AudioSource buttonClickAudioSource;

    [SerializeField] private Renderer holeRenderer;
    public Color newBaseHoleColor;
    public Color newBorderHoleColor;

    private float randomBaseChannelOne, randomBaseChannelTwo, randomBaseChannelThree;
    private float randomBorderChannelOne, randomBorderChannelTwo, randomBorderChannelThree;

    void Start()
    {
        changeColorInstance = this;        
    }

    
    public void ChangeColor()
    {
        buttonClickAudioSource.Play();

        randomBaseChannelOne = Random.Range(0f, 1f);
        randomBaseChannelTwo = Random.Range(0f, 1f);
        randomBaseChannelThree = Random.Range(0f, 1f);

        randomBorderChannelOne = Random.Range(0f, 1f);
        randomBorderChannelTwo = Random.Range(0f, 1f);
        randomBorderChannelThree = Random.Range(0f, 1f);

        newBaseHoleColor = new Color(randomBaseChannelOne, randomBaseChannelTwo, randomBaseChannelThree);
        newBorderHoleColor = new Color(randomBorderChannelOne, randomBorderChannelTwo, randomBorderChannelThree);

        holeRenderer.material.SetColor("_Base", newBaseHoleColor);
        holeRenderer.material.SetColor("_Border", newBorderHoleColor);
    }

    public void PlayGame()
    {
        buttonClickAudioSource.Play();
        Invoke("playScene", 0.5f);
    }

    private void playScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
