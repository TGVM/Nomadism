using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private SaveFile saveFile;

    private void Awake()
    {
        if(SaveManager.Instance == null) Instance = this;
    }

    public void SaveToJson(SaveFile newSave)
    {
        string data = JsonUtility.ToJson(newSave);
        string filePath = Application.persistentDataPath + "/SaveFile.Json";
        System.IO.File.WriteAllText(filePath, data);
        Debug.Log(filePath);
    }

    public SaveFile LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/SaveFile.Json";
        string data = System.IO.File.ReadAllText(filePath);

        saveFile = JsonUtility.FromJson<SaveFile>(data);
        return saveFile;
    }

    public void NewGameSave()
    {
        List<UpgradeModel> upgradesList = new List<UpgradeModel>();

        int currency = 0;

        UpgradeModel speed = new UpgradeModel();
        speed.SetName("Speed");
        speed.SetUpgradeCost(5);
        speed.SetCurrentLevel(1);
        speed.SetMaxLevel(5);
        upgradesList.Add(speed);

        UpgradeModel range = new UpgradeModel();
        range.SetName("Range");
        range.SetUpgradeCost(5);
        range.SetCurrentLevel(1);
        range.SetMaxLevel(5);
        upgradesList.Add(range);

        UpgradeModel capacity = new UpgradeModel();
        capacity.SetName("Capacity");
        capacity.SetUpgradeCost(10);
        capacity.SetCurrentLevel(1);
        capacity.SetMaxLevel(5);
        upgradesList.Add(capacity);

        UpgradeModel extraLifes = new UpgradeModel();
        extraLifes.SetName("Extra Lifes");
        extraLifes.SetUpgradeCost(100);
        extraLifes.SetCurrentLevel(1);
        extraLifes.SetMaxLevel(5);
        upgradesList.Add(extraLifes);

        UpgradeModel enemySpawnDelay = new UpgradeModel();
        enemySpawnDelay.SetName("Enemy Spawn Delay");
        enemySpawnDelay.SetUpgradeCost(10);
        enemySpawnDelay.SetCurrentLevel(1);
        enemySpawnDelay.SetMaxLevel(5);
        upgradesList.Add(enemySpawnDelay);

        UpgradeModel newObjects = new UpgradeModel();
        newObjects.SetName("New Objects");
        newObjects.SetUpgradeCost(100);
        newObjects.SetCurrentLevel(1);
        newObjects.SetMaxLevel(3);
        upgradesList.Add(newObjects);

        UpgradeModel miniMap = new UpgradeModel();
        miniMap.SetName("Minimap");
        miniMap.SetUpgradeCost(100);
        miniMap.SetCurrentLevel(0);
        miniMap.SetMaxLevel(3);
        upgradesList.Add(miniMap);

        UpgradeModel numberOfEnemies = new UpgradeModel();
        numberOfEnemies.SetName("Number of Enemies");
        numberOfEnemies.SetUpgradeCost(500);
        numberOfEnemies.SetCurrentLevel(1);
        numberOfEnemies.SetMaxLevel(3);
        upgradesList.Add(numberOfEnemies);
        
        saveFile = new SaveFile();
        saveFile.currency = currency;
        saveFile.upgradesList = upgradesList;
        SaveToJson(saveFile);
    }

}

[System.Serializable]
public class  SaveFile
{
    public int currency;
    public List<UpgradeModel> upgradesList = new List<UpgradeModel>();
}

[System.Serializable]
public class UpgradeModel {
    public string name;
    public int upgradeCost;
    public int currentLevel;
    public int maxLevel;

    public void SetName(string name)
    {
        this.name = name;
    }
    public void SetUpgradeCost(int uc)
    {
        this.upgradeCost = uc;
    }
    public void SetCurrentLevel(int cl)
    {
        this.currentLevel = cl;
    }
    public void SetMaxLevel(int ml)
    {
        this.maxLevel = ml;
    }
    public string GetName()
    {
        return name;
    }
    public int GetUpgradeCost()
    {
        return upgradeCost;
    }
    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    public int GetMaxLevel()
    {
        return maxLevel;
    }
}