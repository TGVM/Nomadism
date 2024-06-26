using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{

    [SerializeField] float stunTime;
    [SerializeField] string objectName;

    public float getStunTime()
    {
        return stunTime;
    }

    public string getName()
    {
        return objectName;
    }
}
