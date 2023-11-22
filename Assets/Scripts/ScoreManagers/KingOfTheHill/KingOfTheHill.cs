using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingOfTheHill : MonoBehaviour
{

    // struct to hold the game state
    struct ScoreStruct
    {
        public int timeOnHill1;
        public int timeOnHill2;
    }

    // variable for game state
    ScoreStruct gameScore;

    // print the score to the console
    private void showScore()
    {
        Debug.Log("ONE : " + gameScore.timeOnHill1 + " TWO : " + gameScore.timeOnHill2);
    }

    private void listenOnTopOfHill()
    {
        GameObject OnTopBox = GameObject.Find("OnTopBox");
        CheckIsOnTop checkIsOnTop = OnTopBox.GetComponent<CheckIsOnTop>();
        checkIsOnTop.OnTopOfHill += incrementScore;
    }

    // incriment the score of the given player
    private void incrementScore(string playerName)
    {
        if(playerName == "Player1")
        {
            gameScore.timeOnHill1 += 1;
        }

        else if(playerName == "Player2")
        {
            gameScore.timeOnHill2 += 1;
        }

        showScore();

        // Debug.Log(playerName);
    }

    // Start is called before the first frame update
    void Start()
    {
        listenOnTopOfHill();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
