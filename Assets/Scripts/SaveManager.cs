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
        float currencyMultiplier = 1f;

        UpgradeModel speed = new UpgradeModel();
        speed.SetName("Speed");
        speed.SetUpgradeCost(5);
        speed.SetCurrentLevel(0);
        speed.SetMaxLevel(5);
        speed.SetAddedMultiplier(-0.1f);
        upgradesList.Add(speed);

        UpgradeModel range = new UpgradeModel();
        range.SetName("Range");
        range.SetUpgradeCost(5);
        range.SetCurrentLevel(0);
        range.SetMaxLevel(5);
        range.SetAddedMultiplier(-0.1f);
        upgradesList.Add(range);

        UpgradeModel capacity = new UpgradeModel();
        capacity.SetName("Capacity");
        capacity.SetUpgradeCost(10);
        capacity.SetCurrentLevel(0);
        capacity.SetMaxLevel(5);
        capacity.SetAddedMultiplier(-0.1f);
        upgradesList.Add(capacity);

        UpgradeModel extraLifes = new UpgradeModel();
        extraLifes.SetName("Extra Lifes");
        extraLifes.SetUpgradeCost(100);
        extraLifes.SetCurrentLevel(0);
        extraLifes.SetMaxLevel(5);
        extraLifes.SetAddedMultiplier(-0.2f);
        upgradesList.Add(extraLifes);

        UpgradeModel enemySpawnDelay = new UpgradeModel();
        enemySpawnDelay.SetName("Enemy Spawn Delay");
        enemySpawnDelay.SetUpgradeCost(10);
        enemySpawnDelay.SetCurrentLevel(0);
        enemySpawnDelay.SetMaxLevel(5);
        enemySpawnDelay.SetAddedMultiplier(-0.15f);
        upgradesList.Add(enemySpawnDelay);

        UpgradeModel newObjects = new UpgradeModel();
        newObjects.SetName("New Objects");
        newObjects.SetUpgradeCost(100);
        newObjects.SetCurrentLevel(3);
        newObjects.SetMaxLevel(3);
        newObjects.SetAddedMultiplier(-0.15f);
        upgradesList.Add(newObjects);

        UpgradeModel miniMap = new UpgradeModel();
        miniMap.SetName("Minimap");
        miniMap.SetUpgradeCost(100);
        miniMap.SetCurrentLevel(3);
        miniMap.SetMaxLevel(3);
        miniMap.SetAddedMultiplier(-0.15f);
        upgradesList.Add(miniMap);

        UpgradeModel numberOfEnemies = new UpgradeModel();
        numberOfEnemies.SetName("Number of Enemies");
        numberOfEnemies.SetUpgradeCost(500);
        numberOfEnemies.SetCurrentLevel(0);
        numberOfEnemies.SetMaxLevel(3);
        numberOfEnemies.SetAddedMultiplier(1f);
        upgradesList.Add(numberOfEnemies);
        
        saveFile = new SaveFile();
        saveFile.currency = currency;
        saveFile.currencyMultiplier = currencyMultiplier;
        saveFile.upgradesList = upgradesList;
        SaveToJson(saveFile);
    }

}

[System.Serializable]
public class  SaveFile
{
    public int currency;
    public float currencyMultiplier;
    public List<UpgradeModel> upgradesList = new List<UpgradeModel>();
}

[System.Serializable]
public class UpgradeModel {
    public string name;
    public int upgradeCost;
    public int currentLevel;
    public int maxLevel;
    public float addedMultiplier;

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
    public void SetAddedMultiplier(float am)
    {
        this.addedMultiplier = am;
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
    public float GetAddedMultiplier()
    {
        return addedMultiplier;
    }
}