using UnityEngine;
using System.Collections;
using MHomiLibrary;
using System.Collections.Generic;

public enum E_S_PANDARIA_SOUND
{
    E_EATCELL_1,            // 0
    E_EATCELL_2,            // 1
    E_SHOTBULLET,           // 2
    E_EATBULLET,            // 3
    E_SLIEMEAT_1,           // 4
    E_SLIMEEAT_2,           // 5
    E_CHILDCELLEAT,         // 6
    E_LANDINETOUCH,         // 7
    E_LANDMINECELLEAT,      // 8
    E_LANDMINESHOT,         // 9 
    E_SLIMECLONEATTACK,     // 10
    E_DIE,                  // 11
    E_BGM_TESTBGM,          // 12
    E_OPEN,                 // 13
    E_SCROLLSOUND,          // 14
    E_STARTBUTTON,          // 15
    E_SOUND_MAX             // 16
}


public class HSoundMng : MGameSoundMng<HSoundMng>
{

    public static List<string> SoundNames;

    public void Awake()
    {

        SoundNames = new List<string>();

        foreach (AudioClip clip in GameSoundList)
        {
            SoundNames.Add(clip.name);
        }

    }

    public static bool isPlaying(E_S_PANDARIA_SOUND Sound)
    {
        List<AudioSource> ChannelList = new List<AudioSource>(I.AudioManager.GetComponentsInChildren<AudioSource>());

        if (ChannelList != null)
        {
            for (int i = 0; i < ChannelList.Count; i++)
            {
                if (ChannelList[i].clip != null && ChannelList[i].clip.name.CompareTo(Sound.ToString()) == 0)
                {
                    return ChannelList[i].isPlaying;
                }
            }
        }

        return false;
    }

    public static void Play(E_S_PANDARIA_SOUND Sound, bool bLoop = false, bool bBGM = false)
    {
        //if (HDataMng.I.PlayerMeInfo.bSoundEffect_Flag == true)
        //{
        //    I.Play(SoundNames[(int)Sound], bLoop, bBGM);
        //}
        //else
        //{
        //    //Debug.Log("효과음 끔");
        //}
    }

    public static void SetAVolume(float fSound, bool bBGM = false)
    {
        I.SetVolume(fSound, bBGM);
    }

    public static void AStop(bool bBGM = false)
    {
        I.Stop(bBGM);
    }

    public static void MainBGMPlay(E_S_PANDARIA_SOUND Sound, bool bLoop = false, bool bBGM = false)
    {
        //if (HDataMng.I.PlayerMeInfo.bBGM_Flag == true)
        //{
        //    I.Play(SoundNames[(int)Sound], bLoop, bBGM);
        //}
        //else
        //{
        //    //Debug.Log("배경음 끔");
        //}
    }


    //public AudioSource      soundEffect;
    //public AudioClip[]      soundEffectList;

    //public AudioSource      soundBGM;
    //public AudioClip[]      soundBGmList;

    //private void Start()
    //{
    //    soundBGM.clip = soundBGmList[0];
    //    soundBGM.Play();
    //}

    //// ------------------------- 효과음 ------------------------- //
    //public void EffectVolumeOff()
    //{
    //    soundEffect.volume = 0.0f;
    //}

    //public void EffectVolumeOn()
    //{
    //    soundEffect.volume = 1.0f;
    //}

    //public void EffectSoundPlay(int a)
    //{
    //    soundEffect.clip = soundEffectList[a];
    //    soundEffect.Play();
    //}


    //// ------------------------- 배경음 ------------------------- //
    //public void BGMVolumeOff()
    //{
    //    soundBGM.volume = 0.0f;
    //}
    //public void BGMVolumeOn()
    //{
    //    soundBGM.volume = 1.0f;
    //}
    //public void BGMSoundPlay(int a)
    //{
    //    soundBGM.clip = soundBGmList[a];
    //    soundBGM.Play();
    //}

}
