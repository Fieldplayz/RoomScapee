using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.InputSystem;

public class InventorySync : MonoBehaviourPunCallbacks
{
    public GameObject inventoryPanel;
    public GameObject Content;
    public GameObject ItemPrefab;

    public List<Items> itemList = new List<Items>();

    private bool state = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
            Destroy(inventoryPanel);
        }
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
        UpdateInventory();
    } 
    public void RemoveFromInventory(Items item)
    {
        itemList.Remove(item);
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        for (var i = Content.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(Content.transform.GetChild(i).gameObject);
        }
        foreach (var item in itemList)
        {
            ItemPrefab.GetComponentInChildren<Image>().sprite = item.Icon;
            ItemPrefab.GetComponentInChildren<TMPro.TMP_Text>().text = item.Name;
            Instantiate(ItemPrefab, Content.transform);
        }
    }

    private void UseItem()
    {

    }
}
