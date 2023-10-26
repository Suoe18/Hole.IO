using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimerScript : MonoBehaviour
{

    public static GameTimerScript gameTimerInstance;
    [SerializeField] TMP_Text gameTimerTextDisplay;

    public int minutesLeft = 1;
    public int secondsLeft = 0;
    public bool isPlaying = false;

    bool minutesIsDone = false;
    bool secondIsDone = false;

    public bool gameIsDone;

    void Start()
    {
        gameTimerTextDisplay.text = "Time Left: " + minutesLeft + ":0" + secondsLeft;
        gameTimerInstance = this;
        gameIsDone = false;
    }


    void Update()
    {        
        if (minutesLeft == 0)
        {
            if (secondsLeft == 0)
            {
                minutesIsDone = true;
                secondIsDone = true;
                gameIsDone = true;
            }
        }

        if (!isPlaying && !minutesIsDone && !secondIsDone)
        {
            StartCoroutine(gameTimer());
        }
    }

    IEnumerator gameTimer()
    {
        isPlaying = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (minutesLeft > 0 && secondsLeft < 0)
        {
            minutesLeft -= 1;
            secondsLeft = 59;

            if (secondsLeft < 10)
            {
                gameTimerTextDisplay.text = "Time Left: " + minutesLeft + ":0" + secondsLeft;
            }
            else
            {
                gameTimerTextDisplay.text = "Time Left: " + minutesLeft + ":" + secondsLeft;
            }
        }
        else
        {
            if (secondsLeft < 10)
            {
                gameTimerTextDisplay.text = "Time Left: " + minutesLeft + ":0" + secondsLeft;
            }
            else
            {
                gameTimerTextDisplay.text = "Time Left: " + minutesLeft + ":" + secondsLeft;
            }
        }

        isPlaying = false;
    }
}
