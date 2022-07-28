using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonRoom : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    //Host and guest variables might be useless and should be removed
    private void SpawnPlayer()
    {
        GameObject player;

        if (PhotonNetwork.IsMasterClient)
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, player1.transform.position, player1.transform.rotation);
            GameManager.host = player;
        }
        else
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, player2.transform.position, player2.transform.rotation);
            GameManager.guest = player;
        }

        
    }
}
