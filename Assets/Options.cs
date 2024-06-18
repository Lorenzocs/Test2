using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider sliderMusic;
    public Slider sliderSonido;
    public Toggle toggleMusic;
    public Toggle toggleSound;


    void Start()
    {
        float musicVolume;
        mixer.GetFloat("VolumeMusic", out musicVolume);
        sliderMusic.value = musicVolume;


        float soundVolume;
        mixer.GetFloat("SoundMusic", out soundVolume);
        sliderSonido.value = soundVolume;
    }


    public void OnVolumeMusicChange()
    {
        float musicVolume = sliderMusic.value;
        mixer.SetFloat("VolumeMusic", musicVolume);

        toggleMusic.isOn = musicVolume > -80;

    }

    public void OnVolumeSoundChange()
    {
        float soundVolume = sliderSonido.value;
        mixer.SetFloat("VolumeSound", soundVolume);

        toggleSound.isOn = soundVolume > -80;
    }

    public void OnToggleMusic()
    {
        if (sliderMusic.value <= -80)
        {
            toggleMusic.isOn = false;
            return;
        }
        if (toggleMusic.isOn)
        {
            mixer.SetFloat("VolumeMusic", sliderMusic.value);
        }
        else
        {
            mixer.SetFloat("VolumeMusic", -80f);

        }
    }

    public void OnToggleSound()
    {
        if (sliderSonido.value <= -80)
        {
            toggleSound.isOn = false;
            return;
        }

        if (toggleSound.isOn)
        {
            mixer.SetFloat("VolumeSound", sliderSonido.value);
        }
        else
        {
            mixer.SetFloat("VolumeSound", -80f);

        }
    }
}
