using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagementScript : MonoBehaviour
{

    public int scorePoints = 0;
    private int holeLevel = 1;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        scoringSystem();
    }

    private void scoringSystem()
    {
        scorePoints++;
        UIScript.uiScriptInstance.addScore();

        if(scorePoints % 10 == 0)
        {
            if(holeLevel <= 3)
            {
                StartCoroutine(OnChangePosition.onChangePositionInstance.holeScale());
                holeLevel++;
            }            
        }
    }
}
