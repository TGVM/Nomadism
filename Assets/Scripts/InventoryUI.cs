using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inventoryText;
    private bool ready = false;
    private string currentItems = "0";
    private string maxItems = "";


    private void Awake()
    {
        if(InventoryManager.Instance.HasPlayer())
        {
            UpdateMaxItems();
        }
    }

    private void Start()
    {
        Player.OnAnyObjectPicked += Player_OnAnyObjectPicked;
        Player.OnAnyObjectPut += Player_OnAnyObjectPut;
    }

    private void Player_OnAnyObjectPut(object sender, System.EventArgs e)
    {
        UpdateCurrentItems();
    }

    private void Player_OnAnyObjectPicked(object sender, System.EventArgs e)
    {
        UpdateCurrentItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (maxItems == "" && InventoryManager.Instance.HasPlayer())
        {
            UpdateMaxItems();
        }
        VisualUpdate();
    }

    private void VisualUpdate()
    {

        inventoryText.text = "Items: " + currentItems + "/" + maxItems;
    }

    private void UpdateCurrentItems()
    {
        currentItems = InventoryManager.Instance.GetCurrentItems().ToString();
    }

    private void UpdateMaxItems()
    {
        maxItems = InventoryManager.Instance.GetMaxItems().ToString();
    }

}
