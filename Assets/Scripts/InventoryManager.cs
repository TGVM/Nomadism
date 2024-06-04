using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private Player currentPlayer;

     void Awake()
    {
        if(RunManager.Instance != null) currentPlayer = RunManager.Instance.GetCurrentPlayer();
        Instance = this;
    }

    private void Update()
    {
        if(currentPlayer == null && RunManager.Instance != null) {
            currentPlayer = RunManager.Instance.GetCurrentPlayer();
        }
    }

    public int GetCurrentItems()
    {
        return currentPlayer.GetCurrentItems();
    }

    public int GetMaxItems()
    {
        return currentPlayer.GetMaxItems();
    }

    public bool HasPlayer() {  return currentPlayer != null; }

}
