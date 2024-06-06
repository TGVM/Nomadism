using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager Instance { get; private set; }

    public class UpgradeModel
    {
        string name;
        int upgradeCost;
        int currentLevel;
        int maxLevel;

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

    private UpgradeModel speed;
    private UpgradeModel range;
    private UpgradeModel capacity;
    private UpgradeModel extraLifes;
    private UpgradeModel enemySpawnDelay;
    private UpgradeModel newObjects;
    private UpgradeModel miniMap;
    private UpgradeModel numberOfEnemies;

    private int currency = 0;

    private List<UpgradeModel> upgradesList;


    private void Awake()
    {
        if(upgradesList == null)
        {
            upgradesList = new List<UpgradeModel>();
        }
        if(speed == null)
        {
            speed = new UpgradeModel();
            speed.SetName("Speed");
            speed.SetUpgradeCost(5);
            speed.SetCurrentLevel(1);
            speed.SetMaxLevel(5);
            upgradesList.Add(speed);
        }
        if (range == null)
        {
            range = new UpgradeModel();
            range.SetName("Range");
            range.SetUpgradeCost(5);
            range.SetCurrentLevel(1);
            range.SetMaxLevel(5);
            upgradesList.Add(range);
        }
        if (capacity == null)
        {
            capacity = new UpgradeModel();
            capacity.SetName("Capacity");
            capacity.SetUpgradeCost(10);
            capacity.SetCurrentLevel(1);
            capacity.SetMaxLevel(5);
            upgradesList.Add(capacity);
        }
        if (extraLifes == null)
        {
            extraLifes = new UpgradeModel();
            extraLifes.SetName("Extra Lifes");
            extraLifes.SetUpgradeCost(100);
            extraLifes.SetCurrentLevel(1);
            extraLifes.SetMaxLevel(5);
            upgradesList.Add(extraLifes);
        }
        if (enemySpawnDelay == null)
        {
            enemySpawnDelay = new UpgradeModel();
            enemySpawnDelay.SetName("Enemy Spawn Delay");
            enemySpawnDelay.SetUpgradeCost(10);
            enemySpawnDelay.SetCurrentLevel(1);
            enemySpawnDelay.SetMaxLevel(5);
            upgradesList.Add(enemySpawnDelay);
        }
        if (newObjects == null)
        {
            newObjects = new UpgradeModel();
            newObjects.SetName("New Objects");
            newObjects.SetUpgradeCost(100);
            newObjects.SetCurrentLevel(1);
            newObjects.SetMaxLevel(3);
            upgradesList.Add(newObjects);
        }
        if (miniMap == null)
        {
            miniMap = new UpgradeModel();
            miniMap.SetName("Minimap");
            miniMap.SetUpgradeCost(100);
            miniMap.SetCurrentLevel(0);
            miniMap.SetMaxLevel(3);
            upgradesList.Add(miniMap);
        }
        if (numberOfEnemies == null)
        {
            numberOfEnemies = new UpgradeModel();
            numberOfEnemies.SetName("Number of Enemies");
            numberOfEnemies.SetUpgradeCost(500);
            numberOfEnemies.SetCurrentLevel(1);
            numberOfEnemies.SetMaxLevel(3);
            upgradesList.Add(numberOfEnemies);
        }
        UpdateCurrencyWhenGameOver(RunManager.Instance.GetLastCurrencyRecorded());
        Instance = this;
    }

    
    public void Upgrade(string upgradeName) {
    //check in list of upgradeModel for a matching name and upgrade it
        UpgradeModel upgrade = FindUpgradeModelByName(upgradeName);
        if(isUpgradeValid(currency, upgrade))
        {
            currency -= upgrade.GetUpgradeCost();
            int newCost = (int)(upgrade.GetUpgradeCost() * 1.4f);
            upgrade.SetUpgradeCost(newCost);
        }
    }

    public UpgradeModel FindUpgradeModelByName(string name) {
        foreach(UpgradeModel upgrade in upgradesList)
        {
            if(upgrade.GetName().Equals(name)) return upgrade; 
        }
        return null;
    }

    public bool isUpgradeValid(int currency, UpgradeModel um) {
        return currency >= um.GetUpgradeCost() && um.GetCurrentLevel()<um.GetMaxLevel();
    }

    public void UpdateCurrencyWhenGameOver(int addedValue)
    {
        currency += addedValue;
    }

    public int GetCurrency() { return currency; }

}
