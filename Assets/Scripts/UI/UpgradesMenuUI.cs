using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesMenuUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI currencyText;


    [SerializeField] private Button speedUpgradeButton;
    [SerializeField] private Button rangeUpgradeButton;
    [SerializeField] private Button capacityUpgradeButton;
    [SerializeField] private Button extraLifesUpgradeButton;
    [SerializeField] private Button enemySpawnDelayUpgradeButton;
    [SerializeField] private Button newObjectsUpgradeButton;
    [SerializeField] private Button miniMapUpgradeButton;
    [SerializeField] private Button numberOfEnemiesUpgradeButton;

    [SerializeField] private TextMeshProUGUI speedUpgradeText;
    [SerializeField] private TextMeshProUGUI rangeUpgradeText;
    [SerializeField] private TextMeshProUGUI capacityUpgradeText;
    [SerializeField] private TextMeshProUGUI extraLifesUpgradeText;
    [SerializeField] private TextMeshProUGUI enemySpawnDelayUpgradeText;
    [SerializeField] private TextMeshProUGUI newObjectsUpgradeText;
    [SerializeField] private TextMeshProUGUI miniMapUpgradeText;
    [SerializeField] private TextMeshProUGUI numberOfEnemiesUpgradeText;

    [SerializeField] private Button continueButton;


    private void Awake()
    {
        speedUpgradeButton.onClick.AddListener(() =>
        {
            UpgradesManager.Instance.Upgrade("Speed");
        });
        rangeUpgradeButton.onClick.AddListener(() =>
        {
            UpgradesManager.Instance.Upgrade("Range");

        }); 
        capacityUpgradeButton.onClick.AddListener(() =>
        {
            UpgradesManager.Instance.Upgrade("Capacity");
        });
        extraLifesUpgradeButton.onClick.AddListener(() =>
        {
            UpgradesManager.Instance.Upgrade("Extra Lifes");
        });
        enemySpawnDelayUpgradeButton.onClick.AddListener(() =>
        {
            UpgradesManager.Instance.Upgrade("Enemy Spawn Delay");
        });
        newObjectsUpgradeButton.onClick.AddListener(() =>
        {

        });
        miniMapUpgradeButton.onClick.AddListener(() =>
        {
            UpgradesManager.Instance.Upgrade("Minimap");
        });
        numberOfEnemiesUpgradeButton.onClick.AddListener(() =>
        {
            UpgradesManager.Instance.Upgrade("Number of Enemies");
        });

        continueButton.onClick.AddListener(() =>
        {
            UpgradesManager.Instance.ContinueButton();
        });
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        VisualUpdate();
        UpdateSpeedCostUI();
        UpdateRangeCostUI();
        UpdateCapacityCostUI();
        UpdateExtraLifesCostUI();
        UpdateEnemyDelayCostUI();

        UpdateMinimapCostUI();
        UpdateNumberOfEnemiesCostUI();
    }

    private void VisualUpdate()
    {
        currencyText.text = UpgradesManager.Instance.GetCurrency().ToString();
    }

    private void UpdateSpeedCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Speed");
        string description = "Increases player speed";
        string levelProgress = aux.GetCurrentLevel().ToString() + "/" + aux.GetMaxLevel().ToString();
        speedUpgradeText.text = aux.upgradeCost.ToString()+" "+description+" "+levelProgress;
    }

    private void UpdateRangeCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Range");
        string description = "Increases player range";
        string levelProgress = aux.GetCurrentLevel().ToString() + "/" + aux.GetMaxLevel().ToString();
        rangeUpgradeText.text = aux.upgradeCost.ToString() + " " + description + " " + levelProgress;
    }
    private void UpdateCapacityCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Capacity");
        string description = "Increases player inventory capacity";
        string levelProgress = aux.GetCurrentLevel().ToString() + "/" + aux.GetMaxLevel().ToString();
        capacityUpgradeText.text = aux.upgradeCost.ToString() + " " + description + " " + levelProgress;
    }
    private void UpdateExtraLifesCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Extra Lifes");
        string description = "Increases player extra lifes";
        string levelProgress = aux.GetCurrentLevel().ToString() + "/" + aux.GetMaxLevel().ToString();
        extraLifesUpgradeText.text = aux.upgradeCost.ToString() + " " + description + " " + levelProgress;
    }

    private void UpdateEnemyDelayCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Enemy Spawn Delay");
        string description = "Increases delay before spawning enemy";
        string levelProgress = aux.GetCurrentLevel().ToString() + "/" + aux.GetMaxLevel().ToString();
        enemySpawnDelayUpgradeText.text = aux.upgradeCost.ToString() + " " + description + " " + levelProgress;
    }

    /*
    private void UpdateSpeedCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Speed");
        string description = "Increases delay before spawning enemy";
        string levelProgress = aux.GetCurrentLevel().ToString() + "/" + aux.GetMaxLevel().ToString();
        enemySpawnDelayUpgradeText.text = aux.upgradeCost.ToString() + " " + description + " " + levelProgress;
    }
    */
    private void UpdateMinimapCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Minimap");
        string description = "Minimap shows more things";
        if (aux.GetCurrentLevel() == 0)
        {
            description = "Unlocks minimap";
        }
        string levelProgress = aux.GetCurrentLevel().ToString() + "/" + aux.GetMaxLevel().ToString();
        miniMapUpgradeText.text = aux.upgradeCost.ToString() + " " + description + " " + levelProgress;
    }

    private void UpdateNumberOfEnemiesCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Number of Enemies");
        string description = "Increases number of enemies";
        string levelProgress = aux.GetCurrentLevel().ToString() + "/" + aux.GetMaxLevel().ToString();
        numberOfEnemiesUpgradeText.text = aux.upgradeCost.ToString() + " " + description + " " + levelProgress;
    }
}
