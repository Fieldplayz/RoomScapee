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
    public GameObject Content2;
    public GameObject ItemPrefab;

    public List<Items> itemList = new List<Items>();

    public Items primaryItem;

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

    
    public void OnOpenOrCloseInventory(InputAction.CallbackContext context)
    {
        inventoryPanel.GetComponentInChildren<Button>().onClick.AddListener(() => Test(5));
        if (state)
        {
            state = false;
        }
        else
        {
            state = true;
        }        
        inventoryPanel.SetActive(state);
        UpdateInventory();
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
            ItemPrefab.GetComponentInChildren<Button>().onClick.AddListener(() => SetPrimaryItem(item));
            Instantiate(ItemPrefab, Content.transform);
        }
    }


    public void SetPrimaryItem(Items item)
    {
        primaryItem = item;
    }

    public void Test(int number)
    {

    }
}
