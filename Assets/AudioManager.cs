using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioClip[] audioClipsFoots;

    public AudioSource source;
    public static AudioManager instance;


    public void Awake()
    {
        instance = this;
    }

    public void PlaySound(string name)
    {
        AudioClip clip = BuscarAudio(name);

        if (clip != null)
        {
            source.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("El sonido " + name + " no existe");
        }
    }

    public void PlaySoundFoot()
    {
        int random = Random.Range(0, audioClipsFoots.Length);
        AudioClip clip = audioClipsFoots[random];
        source.PlayOneShot(clip);

    }

    private AudioClip BuscarAudio(string name)
    {
        foreach (var clip in audioClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }

        return null;
    }

}
