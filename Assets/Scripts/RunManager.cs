using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance { get; private set; }

    private Player currentPlayer;
    private EnemyScript currentEnemy;


    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private EnemyScript EnemyPrefab;
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private Transform EnemyPosition;




    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SpawnPlayer();
        currentEnemy = Instantiate(EnemyPrefab, EnemyPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopRun()
    {
        currentPlayer.BlockControl();
        TimerManager.Instance.StopRun();
    }

    void SpawnPlayer()
    {
        currentPlayer = Instantiate(PlayerPrefab, PlayerPosition);

    }

    void SpawnEnemy()
    {

    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

}
