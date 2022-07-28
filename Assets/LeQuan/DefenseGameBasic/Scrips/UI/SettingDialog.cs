using System.Collections;
using System.Collections.Generic;
using LQ.DefenseBasic;
using UnityEngine;
using UnityEngine.UI;

public class SettingDialog : Dialog,IComponentChecking
{
    public Slider musicSlider;
    public Slider soundSlider;
    

    public override void ShowHide(bool active)
    {
        base.ShowHide(active);
        if(IsComponentsNull()) return;
        musicSlider.value = Pref.musicVol;
        soundSlider.value = Pref.soundVol;
    }

    public void OnMusicChange(float value)
    {
        if(IsComponentsNull()) return;

        AudioController.Instance.musicVol = value;
        AudioController.Instance.musicAudioSource.volume = value;
        Pref.musicVol = value;
    }
    
    public void OnSoundChange(float value)
    {
        if(IsComponentsNull()) return;

        AudioController.Instance.soundVol = value;
        AudioController.Instance.soundAudioSource.volume = value;
        Pref.soundVol = value;
    }

    public bool IsComponentsNull()
    {
        return  AudioController.Instance == null ||  musicSlider == null || soundSlider == null;

    }
}
