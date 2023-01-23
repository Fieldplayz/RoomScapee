using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManagerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public bool player1, player2;
    public int myPlayerNumber;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public override void OnJoinedRoom()
    {    
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("you joind");
            if (player1 || player2)
            {
                if (player1)
                {
                    player2 = true;
                    myPlayerNumber = 2;
                }
                if (player2)
                {
                    player1 = true;
                    myPlayerNumber = 1;
                }
            }
            else
            {
                player1 = true;
                myPlayerNumber = 1;
            }
        }   
    }

    public override void OnLeftRoom()
    {
        switch (myPlayerNumber)
        {
            case 1:
                player1 = false;
                break;
            case 2:
                player2 = false;
                break;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(player1);
            stream.SendNext(player2);
        }
        else
        {
            player1 = (bool)stream.ReceiveNext();
            player2 = (bool)stream.ReceiveNext();
        }
    }
}
