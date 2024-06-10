using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesMenuUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI MultiplierLabelText;
    [SerializeField] private TextMeshProUGUI MultiplierValueText;


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
            UpgradesManager.Instance.Upgrade("New Objects");
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
        UpdateNewObjectsCostUI();
        UpdateMinimapCostUI();
        UpdateNumberOfEnemiesCostUI();
    }

    private void VisualUpdate()
    {
        currencyText.text = UpgradesManager.Instance.GetCurrency().ToString();
        float multiplier = UpgradesManager.Instance.GetCurrencyMultiplier();
        MultiplierValueText.text = multiplier.ToString("F2");
        if(multiplier < 1)
        {
            MultiplierLabelText.color = Color.red;
            MultiplierValueText.color = Color.red;
        }
        else
        {
            MultiplierLabelText.color = Color.green;
            MultiplierValueText.color = Color.green;
        }
    }

    private void UpdateSpeedCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Speed");
        string description = "Increases player speed";
        speedUpgradeText.text = GetFullDescription(aux, description);
    }

    private void UpdateRangeCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Range");
        string description = "Increases player range";
        rangeUpgradeText.text = GetFullDescription(aux, description);
    }
    private void UpdateCapacityCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Capacity");
        string description = "Increases player inventory capacity";
        capacityUpgradeText.text = GetFullDescription(aux, description);
    }
    private void UpdateExtraLifesCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Extra Lifes");
        string description = "Increases player extra lifes";
        extraLifesUpgradeText.text = GetFullDescription(aux, description);
    }

    private void UpdateEnemyDelayCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Enemy Spawn Delay");
        string description = "Increases delay before spawning enemy";
        enemySpawnDelayUpgradeText.text = GetFullDescription(aux, description);
    }

    private void UpdateNewObjectsCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("New Objects");
        string description = "Unlocks stone to be collected";
        if (aux.GetCurrentLevel() == 0)
        {
            description = "Increases chance of spawning stone";
        }
        newObjectsUpgradeText.text = GetFullDescription(aux, description);
    }

    private void UpdateMinimapCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Minimap");
        string description = "Minimap shows more things";
        if (aux.GetCurrentLevel() == 0)
        {
            description = "Unlocks minimap";
        }
        miniMapUpgradeText.text = GetFullDescription(aux, description);
    }

    private void UpdateNumberOfEnemiesCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Number of Enemies");
        string description = "Increases number of enemies";

        numberOfEnemiesUpgradeText.text = GetFullDescription(aux, description);
    }

    private string GetFullDescription(UpgradeModel aux, string description)
    {
        string levelProgress = aux.GetCurrentLevel().ToString() + "/" + aux.GetMaxLevel().ToString();
        return aux.upgradeCost.ToString() + " " + description + " " + levelProgress;
    }

}
