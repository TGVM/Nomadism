using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private Player currentPlayer;
    private int maxItems;
    private int woodCount;
    private int stoneCount;

     void Awake()
    {
        if(RunManager.Instance != null) currentPlayer = RunManager.Instance.GetCurrentPlayer();
        maxItems = currentPlayer.GetMaxItems();
        woodCount = 0;
        stoneCount = 0;
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
        return woodCount + stoneCount;
    }

    public int GetMaxItems()
    {
        return maxItems;
    }

    public void FillInventory(SpawnedObject targetObject)
    {
        if (string.Compare(targetObject.getName(), "wood") == 0) { 
            woodCount += 1; 
        }
        else if (string.Compare(targetObject.getName(), "stone") == 0) {  
            stoneCount += 1; 
        }
    }

    public string decideTrap()
    {
        if(stoneCount > 0)
        {
            stoneCount--;
            return "stone";
        }
        else if(woodCount > 0)
        {
            woodCount--;
            return "wood";
        }
        return "";
    }

    public bool HasPlayer() {  return currentPlayer != null; }

}
