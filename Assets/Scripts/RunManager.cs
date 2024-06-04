using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance { get; private set; }

    public event EventHandler OnStateChanged;

    private enum State
    {
        GamePlaying,
        GameOver,
    }

    private State state;
    private Player currentPlayer;
    private EnemyScript currentEnemy;
    [SerializeField] private float timerToSpawnEnemy = 0f;

    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private EnemyScript EnemyPrefab;
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private Transform EnemyPosition;




    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        SpawnPlayer();
        state = State.GamePlaying;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.GamePlaying:
                if (timerToSpawnEnemy > 0f)
                {
                    timerToSpawnEnemy -= Time.deltaTime;
                }
                else
                {
                    if (currentEnemy == null) SpawnEnemy();
                }
                break;
            case State.GameOver:
                break;
        }
        
    }

    public void StopRun()
    {
        currentPlayer.BlockControl();
        TimerManager.Instance.StopRun();
        state = State.GameOver;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    void SpawnPlayer()
    {
        currentPlayer = Instantiate(PlayerPrefab, PlayerPosition);

    }

    void SpawnEnemy()
    {
        currentEnemy = Instantiate(EnemyPrefab, EnemyPosition);
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

}
