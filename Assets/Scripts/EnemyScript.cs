using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Vector3 movePosition;
    private Player playerRef;
    private bool stunned = false;

    private float startDelay;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float stunTimerMax = 3f;
    [SerializeField] private float stunTimer = 0f;

    const float INITIAL_SPEED = 10f;
    //SaveFile
    private SaveFile saveFile;

    // Start is called before the first frame update
    void Start()
    {
        saveFile = SaveManager.Instance.LoadFromJson();
        startDelay = saveFile.upgradesList[4].currentLevel;
        movePosition = playerRef.transform.position;
        speed = INITIAL_SPEED + saveFile.upgradesList[9].GetCurrentLevel();

    }

    private void Awake()
    {
        playerRef = RunManager.Instance.GetCurrentPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(startDelay > 0)
        {
            startDelay -= Time.deltaTime;
            return;
        }
        if(!stunned)
        {
            if(playerRef != null)
            {
                Movement();
            }
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
            float stunTimer = other.GetComponent<SpawnedObject>().getStunTime();
            stunned = true;
            stunTimerMax = stunTimer;
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
        else if (other.gameObject.CompareTag("Enemy"))
        {
            //stunned = true;
            //stunTimerMax = 1f;
            //DO SOMETHING
        }
    }

    private Vector3 RandomPosition()
    {
        float auxX = this.transform.position.x;
        float auxY = this.transform.position.y;
        float auxZ = this.transform.position.z;

        Vector3 aux = Vector3.zero;
        aux.x = Random.Range(auxX - 3f, auxX + 3f);
        aux.y = auxY;
        aux.z = Random.Range(auxZ - 3f, auxZ + 3f);

        return aux;
    }

}
