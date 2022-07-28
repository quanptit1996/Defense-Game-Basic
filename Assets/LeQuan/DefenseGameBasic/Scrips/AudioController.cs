using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LQ.DefenseBasic;
using Random = UnityEngine.Random;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance{ get; private set; }
    [Header("main Setting:")] 
    [Range(0f, 1f)] public float musicVol = 0.3f;
    [Range(0f, 1f)] public float soundVol = 1f;

    public AudioSource musicAudioSource;
    public AudioSource soundAudioSource;

    [Header("Music and Sound in Gameplay:")]
    public AudioClip playerAtk;
    public AudioClip enemyDead;
    public AudioClip gameOver;
    public AudioClip[] bgMusics;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this.gameObject); 
            return;
        }
 
        Instance = this;
        DontDestroyOnLoad( this.gameObject );
    }

    private void Start()
    {
        musicVol = Pref.musicVol;
        soundVol = Pref.soundVol;
        
        musicAudioSource.volume = musicVol;
        soundAudioSource.volume = soundVol;
    }

    public void PlaySound(AudioClip[] sounds,AudioSource audsouce = null)
    {
        if (!audsouce)
            audsouce = soundAudioSource;
        
        if (sounds == null || sounds.Length <= 0 || audsouce == null) 
            return;

        int randomIdx = Random.Range(0, sounds.Length);
        if(sounds[randomIdx])
            audsouce.PlayOneShot(sounds[randomIdx],soundVol);
        
    }

    public void PlaySound(AudioClip sound, AudioSource audsouce = null)
    {
        if (!audsouce)
            audsouce = soundAudioSource;
        
        if (sound == null || audsouce == null) 
            return;
        
        if(sound)
            audsouce.PlayOneShot(sound,soundVol);
    }

    public void PlayMusic(AudioClip[] musics, bool isLoop = true)
    {
        if(musics == null || musics.Length <= 0) return;

        int randInx = Random.Range(0, musics.Length);
        if (musics[randInx])
        {
            musicAudioSource.clip = musics[randInx];
            musicAudioSource.loop = isLoop;
            musicAudioSource.volume = musicVol;
            musicAudioSource.Play();
        }
    }

    public void PlayMusic(AudioClip music ,bool isLoop = true)
    {
        musicAudioSource.clip = music;
        musicAudioSource.loop = isLoop;
        musicAudioSource.volume = musicVol;
        musicAudioSource.Play();
    }

    public void SetMusicVolume(float vol)
    {
        if(musicAudioSource == null) return;

        musicAudioSource.volume = vol;
    }

    public void StopMusic()
    {
        if(musicAudioSource == null) return;
        
        musicAudioSource.Stop();
    }

    public void PlayBGMusic()
    {
        PlayMusic(bgMusics);
    }
}
