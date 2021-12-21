using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScores : MonoBehaviour
{
    List<int> playerScores = new List<int> { 0, 0 };
    [SerializeField] List<Text> uiTexts;

    private void Start()
    {
        uiTexts[0].text = "Player " + 1 + ": " + playerScores[0];
        uiTexts[1].text = "Player " + 2 + ": " + playerScores[1];
    }

    public void RegisterGoal(int playerIndex, GameObject ball)
    {
        Destroy(ball);
        playerScores[playerIndex - 1]++;
        uiTexts[playerIndex - 1].text = "Player " + playerIndex + ": " + playerScores[playerIndex - 1];
        //print("player " + playerIndex + " scored");
    }
}
