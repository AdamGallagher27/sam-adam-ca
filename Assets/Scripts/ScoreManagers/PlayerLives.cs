using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    // struct to hold the game state
    struct ScoreStruct {
        public int livesPlayer1;
        public int livesPlayer2;

        public void startingScore()
        {
            this.livesPlayer1 = 5;
            this.livesPlayer2 = 5;
        }

        public void checkIfLossed()
        {
            if(this.livesPlayer1 < 1 )
            {
                Debug.Log("player 2 wins");
            }
            else if(this.livesPlayer2 < 1)
            {
                Debug.Log("player 1 wins");
            }
        }
    }

    // create variable for game state
    ScoreStruct gameScore;

    // print the score to the console
    private void showScore()
    {
        Debug.Log("ONE LIVES : " + gameScore.livesPlayer1 + " TWO LIVES : " + gameScore.livesPlayer2 );
    }

    // listen for player falling of the arena and minus the life of the player
    private void listenOutOfBoundsEvent()
    {
        GameObject outOfBoundsBoundary = GameObject.Find("OutOfBounds1");
        PlayerOutOfBounds playerOutOfBounds = outOfBoundsBoundary.GetComponent<PlayerOutOfBounds>();
        playerOutOfBounds.OnResetPosition += minusLives;
    }

    // instantiate game state struct listen for reset position
    private void Start()
    {
        gameScore = new ScoreStruct();
        gameScore.startingScore();
        showScore();
        listenOutOfBoundsEvent();
    }

    // minus the life of the given player check if one of the players has lossed
    private void minusLives(string playerName)
    {
        if(playerName == "Player1")
        {
            gameScore.livesPlayer1 -= 1;
        }

        else if(playerName == "Player2")
        {
            gameScore.livesPlayer2 -= 1;
        }

        showScore();
        gameScore.checkIfLossed();
    }
 
}
