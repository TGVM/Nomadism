using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipsRefsSO audioClipsRefsSO;

    private void Awake()
    {
        Instance = this;
    }

    private void Playsound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        Playsound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);

    }

    private void Playsound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1.5f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier);
    }

    public void PlayFootstepsSound(Vector3 position, float volume)
    {
        Playsound(audioClipsRefsSO.steps, position, volume);
    }

    public void PlayTreeChopSound(Vector3 position)
    {
        Playsound(audioClipsRefsSO.treeChop, position);
    }

    public void PlayStoneBreakSound(Vector3 position)
    {
        Playsound(audioClipsRefsSO.stoneBreak, position);
    }

}
