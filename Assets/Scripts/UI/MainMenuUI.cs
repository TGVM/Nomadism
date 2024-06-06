using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button quitButton;

    private bool isFirstUpdate = true;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            SaveManager.Instance.NewGameSave();
            Loader.Load(Loader.Scene.GameScene);

        });
        continueButton.onClick.AddListener(() =>
        {
            SaveManager.Instance.LoadFromJson();
            Loader.Load(Loader.Scene.GameScene);

        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        Time.timeScale = 1.0f;

    }

    private void Update()
    {
        
    }
}
