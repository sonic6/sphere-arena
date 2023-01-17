using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonRoom : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    public static int localPlayerID;
    [SerializeField] GameObject player1pos;
    [SerializeField] GameObject player2pos;

    GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    //Host and guest variables might be useless and should be removed
    private void SpawnPlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, player1pos.transform.position, player1pos.transform.rotation);
            player.tag = "PlayerOne";
            GameManager.host = player;
            PhotonNetwork.AllocateViewID(player);
            localPlayerID = player.GetComponent<PhotonView>().ViewID;
        }
        else
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, player2pos.transform.position, player2pos.transform.rotation);
            player.tag = "PlayerTwo";
            GameManager.guest = player;
            PhotonNetwork.AllocateViewID(player);
            localPlayerID = player.GetComponent<PhotonView>().ViewID;
        }
    }
}
