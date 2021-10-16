using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBox : MonoBehaviour
{
    GameScores gameScores;
    [Tooltip("is this player 1 or player 2")]
    [SerializeField] int playerIndex;

    private void Awake()
    {
        gameScores = FindObjectOfType<GameScores>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Sphere>())
        {
            gameScores.RegisterGoal(playerIndex, other.gameObject);
        }
    }
}
