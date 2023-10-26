using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public static UIScript uiScriptInstance;
    [SerializeField] TMP_Text scoreText;

    public int scorePoints = 0;

    void Start()
    {
        uiScriptInstance = this;    
    }

    public void addScore()
    {
        scorePoints++;
        scoreText.text = scorePoints.ToString();
    }
}
