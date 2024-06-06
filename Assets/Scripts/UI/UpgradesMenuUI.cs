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

        });
        newObjectsUpgradeButton.onClick.AddListener(() =>
        {

        });
        miniMapUpgradeButton.onClick.AddListener(() =>
        {

        });
        numberOfEnemiesUpgradeButton.onClick.AddListener(() =>
        {

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
    }

    private void VisualUpdate()
    {
        currencyText.text = UpgradesManager.Instance.GetCurrency().ToString();
    }

    private void UpdateSpeedCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Speed");
        speedUpgradeText.text = aux.upgradeCost.ToString();
    }

    private void UpdateRangeCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Range");
        rangeUpgradeText.text = aux.upgradeCost.ToString();
    }
    private void UpdateCapacityCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Capacity");
        capacityUpgradeText.text = aux.upgradeCost.ToString();
    }
    private void UpdateExtraLifesCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Extra Lifes");
        extraLifesUpgradeText.text = aux.upgradeCost.ToString();
    }
    /*

    private void UpdateSpeedCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Speed");
        speedUpgradeText.text = aux.upgradeCost.ToString();
    }

    private void UpdateSpeedCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Speed");
        speedUpgradeText.text = aux.upgradeCost.ToString();
    }
    private void UpdateSpeedCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Speed");
        speedUpgradeText.text = aux.upgradeCost.ToString();
    }
    private void UpdateSpeedCostUI()
    {
        UpgradeModel aux = UpgradesManager.Instance.FindUpgradeModelByName("Speed");
        speedUpgradeText.text = aux.upgradeCost.ToString();
    }

    */
}
