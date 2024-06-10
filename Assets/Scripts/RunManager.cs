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
    private List<EnemyScript> currentEnemy;
    //[SerializeField] private float timerToSpawnEnemy = 0f;

    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private EnemyScript EnemyPrefab;
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private Transform EnemyPosition;

    private int numberOfEnemies;
    private int numberOfEnemiesSpawned;

    private float timeBetweenSpawns;
    private bool spawnReady = false;
    private bool spawnMore = true;

    private int lastCurrencyRecorded;

    //SaveFile
    private SaveFile saveFile;

    // Start is called before the first frame update
    void Awake()
    {
        currentEnemy = new List<EnemyScript>();
        saveFile = SaveManager.Instance.LoadFromJson();
        numberOfEnemies = saveFile.upgradesList[7].currentLevel + 1;
        numberOfEnemiesSpawned = 0;
        timeBetweenSpawns = 0.5f;
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
                if (spawnMore)
                {
                    if (spawnReady)
                    {
                        
                        SpawnEnemy();
                        CheckAnotherEnemySpawn();
                    }
                    else if (timeBetweenSpawns > 0)
                    {
                        timeBetweenSpawns -= Time.deltaTime;
                    }
                    else if (timeBetweenSpawns <= 0)
                    {
                        spawnReady = true;
                    }
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
        lastCurrencyRecorded = (int)TimerManager.Instance.GetCurrentRunTimer();
        TimerManager.Instance.ResetClock();
        state = State.GameOver;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    void SpawnPlayer()
    {
        currentPlayer = Instantiate(PlayerPrefab, PlayerPosition);

    }

    void SpawnEnemy()
    {
        Vector3 aux = EnemyPosition.position;
        if (numberOfEnemiesSpawned%2==0)
        {
            aux.x *= -1;
            EnemyPosition.position = aux;
        }
        else
        {
            aux.z *= -1;
            EnemyPosition.position = aux;
        }
        currentEnemy.Add(Instantiate(EnemyPrefab, aux, Quaternion.identity));
        numberOfEnemiesSpawned += 1;

        spawnReady = false;
        spawnMore = false;
    }

    private void CheckAnotherEnemySpawn()
    {
        if(currentEnemy.Count < numberOfEnemies)
        {
            spawnMore = true;
            timeBetweenSpawns = saveFile.upgradesList[4].currentLevel + 1;
        }
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public int GetLastCurrencyRecorded()
    {
        return lastCurrencyRecorded;
    }

}
