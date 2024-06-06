using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private Button upgradeMenuButton;

    private void Awake()
    {
        upgradeMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.UpgradesScene);
        });
    }


        // Start is called before the first frame update
    void Start()
    {
        RunManager.Instance.OnStateChanged += Instance_OnStateChanged;
        Hide();
    }

    private void Instance_OnStateChanged(object sender, System.EventArgs e)
    {
        if (RunManager.Instance.IsGameOver())
        {
            int runCurrency = RunManager.Instance.GetLastCurrencyRecorded();
            currencyText.text = runCurrency.ToString();
            if(UpgradesManager.Instance != null)
            {
                UpgradesManager.Instance.UpdateCurrencyWhenGameOver(runCurrency);
            }
            Show();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
