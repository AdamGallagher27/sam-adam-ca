using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBoundPoint : MonoBehaviour
{

    // every game mode must have these functions / struct

    struct ScoreStruct {
        public int pointsPlayer1;
        public int pointsPlayer2;
    }

    ScoreStruct gameScore;

    private void showScore()
    {
        Debug.Log("ONE : " + gameScore.pointsPlayer1 + " TWO : " + gameScore.pointsPlayer2 );
    }


    private void listenOutOfBoundsEvent()
    {
        GameObject outOfBoundsBoundary = GameObject.Find("OutOfBounds1");
        PlayerOutOfBounds playerOutOfBounds = outOfBoundsBoundary.GetComponent<PlayerOutOfBounds>();
        playerOutOfBounds.OnResetPosition += incrementScore;
    }

    // Start is called before the first frame update
    private void Start()
    {
        gameScore = new ScoreStruct();
        showScore();
        listenOutOfBoundsEvent();
    }

    private void incrementScore(string playerName)
    {
        if(playerName == "Player1")
        {
            gameScore.pointsPlayer1 += 1;
        }

        else if(playerName == "Player2")
        {
            gameScore.pointsPlayer2 += 1;
        }

        showScore();
    }
}