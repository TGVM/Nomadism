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

    [SerializeField] private Button continueButton;


    private void Awake()
    {
        speedUpgradeButton.onClick.AddListener(() =>
        {
            
        });
        rangeUpgradeButton.onClick.AddListener(() =>
        {

        }); 
        capacityUpgradeButton.onClick.AddListener(() =>
        {

        });
        extraLifesUpgradeButton.onClick.AddListener(() =>
        {

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
            Loader.Load(Loader.Scene.GameScene);
        });
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        VisualUpdate();
    }

    private void VisualUpdate()
    {
        currencyText.text = RunManager.Instance.GetLastCurrencyRecorded().ToString();
    }

}
