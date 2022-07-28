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

    private void SpawnPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
            PhotonNetwork.Instantiate(playerPrefab.name, player1.transform.position, player1.transform.rotation);
        else
            PhotonNetwork.Instantiate(playerPrefab.name, player2.transform.position, player2.transform.rotation);
    }
}
