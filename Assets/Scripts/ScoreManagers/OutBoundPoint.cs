using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBoundPoint : MonoBehaviour
{

    // every game mode must have these functions / struct
    // struct to hold the game state
    struct ScoreStruct {
        public int pointsPlayer1;
        public int pointsPlayer2;
    }

    // variable for game state
    ScoreStruct gameScore;

    // print the score to the console
    private void showScore()
    {
        Debug.Log("ONE : " + gameScore.pointsPlayer1 + " TWO : " + gameScore.pointsPlayer2 );
    }

    // event listener for when a player falls off the arena
    // then call increment score
    private void listenOutOfBoundsEvent()
    {
        GameObject outOfBoundsBoundary = GameObject.Find("OutOfBounds1");
        PlayerOutOfBounds playerOutOfBounds = outOfBoundsBoundary.GetComponent<PlayerOutOfBounds>();
        playerOutOfBounds.OnResetPosition += incrementScore;
    }

    // Start is called before the first frame update
    // instantiate scorestruct listen for player falls of arena event
    private void Start()
    {
        gameScore = new ScoreStruct();
        showScore();
        listenOutOfBoundsEvent();
    }

    // incriment the score of the given player
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