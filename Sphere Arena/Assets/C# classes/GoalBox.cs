using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GoalBox : MonoBehaviour
{
    GameScores gameScores;
    [Tooltip("is this player 1 or player 2")]
    [SerializeField] int playerIndex;
    [SerializeField] Transform particles;

    private void Awake()
    {
        particles = Instantiate(particles, transform);
        gameScores = FindObjectOfType<GameScores>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Sphere>())
        {
            GetComponent<AudioSource>().Play();
            particles.position = other.transform.position;
            foreach (ParticleSystem sys in particles.GetComponentsInChildren<ParticleSystem>())
                sys.Play();
            gameScores.RegisterGoal(playerIndex, other.gameObject);

            if(PhotonNetwork.IsMasterClient)
                SphereSpawner.spawner.SphereOut();
        }
    }
}
