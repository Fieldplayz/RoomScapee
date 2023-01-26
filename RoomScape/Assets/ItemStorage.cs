using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ItemStorage : MonoBehaviourPunCallbacks
{
    public Items item;

    public void Update()
    {
        Collider2D Collider = Physics2D.OverlapCircle(this.transform.position, 2);
        if (Collider)
        {
            InventorySync Temp = Collider.GetComponent<InventorySync>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (item != null)
                {
                    SendItem(Temp);
                }
                else
                {
                    GetItem(Temp);
                }
            }
        }
    }
    public void SendItem(InventorySync temp)
    { 
        Items itemGet = temp.primaryItem;
        temp.RemoveFromInventory(temp.primaryItem);
        photonView.RPC("SetItem", RpcTarget.All, itemGet);
    }

    [PunRPC]
    public void SetItem(Items items)
    {
        item = items;
    }

    public void GetItem(InventorySync temp)
    {
        temp.AddToInventory(item);
        photonView.RPC("SetItem", RpcTarget.All, null);
    }
}
