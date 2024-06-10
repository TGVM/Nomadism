using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;

    public void Play()
    {
        _particleSystem.Emit(1);
    }
}
