using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform spawnPointRoom1;
    [SerializeField] Transform spawnPointRoom2;
    [SerializeField] GameObject roof1;
    [SerializeField] GameObject roof2;

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            SpawnPlayer();
        }
    }

    public void SpawnPlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPointRoom1.position, spawnPointRoom1.rotation);
            roof2.SetActive(true);
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPointRoom2.position, spawnPointRoom2.rotation);
            roof1.SetActive(true);
        }
    }

    
}
