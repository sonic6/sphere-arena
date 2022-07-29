using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameScores : MonoBehaviour
{
    List<int> playerScores = new List<int> { 0, 0 }; //A list of the scores of the two players
    [SerializeField] List<Text> uiTexts;

    [Tooltip("This value is the required score to win the game in the current scene")]
    [SerializeField] int winningScore;

    private void Start()
    {
        uiTexts[0].text = "Player " + 1 + ": " + playerScores[0];
        uiTexts[1].text = "Player " + 2 + ": " + playerScores[1];
    }

    public void RegisterGoal(int playerIndex, GameObject ball)
    {
        PhotonNetwork.Destroy(ball);
        playerScores[playerIndex - 1]++;
        uiTexts[playerIndex - 1].text = "Player " + playerIndex + ": " + playerScores[playerIndex - 1];
        CheckWinner();
        //print("player " + playerIndex + " scored");
    }

    //Checks if the game has been won by one of the players
    private void CheckWinner()
    {
        if (playerScores[0] == winningScore)
            DeclareWinner("Player 1");
        else if (playerScores[1] == winningScore)
            DeclareWinner("Player 2");

    }

    private void DeclareWinner(string winnerName)
    {
        print(winnerName + " wins");
        PhotonNetwork.LeaveRoom();
        Time.timeScale = 0;
    }
}
