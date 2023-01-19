using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.InputSystem;

public class InventorySync : MonoBehaviour, IPunObservable
{
    public GameObject inventoryPanel;

    public List<Items> itemList = new List<Items>();

    private bool state = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    // this is for the inventory system

    private void Trade()
    {

    } 
    public void OnOpenOrCloseInventory(InputAction.CallbackContext context)
    {
        if (state)
        {
            state = false;
        }
        else
        {
            state = true;
        }        
        inventoryPanel.SetActive(state);
    } 
    public void AddToInventory(Items item)
    {
        itemList.Add(item);
    } 
    public void RemoveFromInventory(Items item)
    {
        itemList.Remove(item);
    }
    private void UseItem()
    {

    }

    // this is for sharing your inventory with other players in the room.

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(itemList);
        }
        else
        {
            itemList = (List<Items>)stream.ReceiveNext(); 
        }
    }
}
