using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager Instance { get; private set; }


    private SaveFile saveFile;

    private int currency = 0;

    private List<UpgradeModel> upgradesList;


    private void Awake()
    {
        saveFile = SaveManager.Instance.LoadFromJson();
        currency = saveFile.currency;
        upgradesList = saveFile.upgradesList;
        UpdateCurrencyWhenGameOver(RunManager.Instance.GetLastCurrencyRecorded());
        Instance = this;
    }

    
    public void Upgrade(string upgradeName) {
        UpgradeModel upgrade = FindUpgradeModelByName(upgradeName);
        if(isUpgradeValid(currency, upgrade))
        {
            currency -= upgrade.GetUpgradeCost();
            int newCost = (int)(upgrade.GetUpgradeCost() * 1.4f);
            upgrade.SetUpgradeCost(newCost);
            upgrade.SetCurrentLevel(upgrade.GetCurrentLevel() + 1);
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

    public void ContinueButton()
    {
        saveFile.currency = currency;
        saveFile.upgradesList = upgradesList;
        SaveManager.Instance.SaveToJson(saveFile);
        Loader.Load(Loader.Scene.GameScene);
    }

}
