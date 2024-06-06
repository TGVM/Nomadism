using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Vector3 movePosition;
    private Player playerRef;
    private bool stunned = false;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float stunTimerMax = 3f;
    [SerializeField] private float stunTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        movePosition = playerRef.transform.position;

    }

    private void Awake()
    {
        playerRef = RunManager.Instance.GetCurrentPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stunned)
        {
            Movement();
        }
        else
        {
            if(stunTimer < stunTimerMax)
            {
                stunTimer += Time.deltaTime;
            }
            else if(TimerManager.Instance.IsRunning())
            {
                stunned = false;
                stunTimer = 0;
            }
        }
    }

    void Movement()
    {
        movePosition = playerRef.transform.position;
        Vector3 targetDirection = movePosition - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 2 * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, movePosition, speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            stunned = true;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            stunned = true;
            if (playerRef.HasExtraLife())
            {
                playerRef.RemoveExtraLife();
            }
            else
            {
                RunManager.Instance.StopRun();
                Destroy(other.gameObject);
            }
        }
    }


}
