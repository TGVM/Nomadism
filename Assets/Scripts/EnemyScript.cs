using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Vector3 movePosition;
    [SerializeField] private Player playerRef;

    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        movePosition = playerRef.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        movePosition = playerRef.transform.position;
        Vector3 targetDirection = movePosition - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 2 * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, movePosition, speed * Time.deltaTime);

    }
}
