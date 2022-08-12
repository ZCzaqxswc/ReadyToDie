using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using MHomiLibrary;
using System.Runtime.InteropServices;
using System;


public class HMng : HSingleton<HMng>
{
    /// <summary>
    /// 고정프레임 변수
    /// </summary>
    public int nFixedFrame = 24;                               

    /// <summary>
    /// 게임시작 
    /// </summary>
    public bool bGameStart = false;  

    /// <summary>
    /// 잠시멈춤
    /// </summary>
    public bool bPause = false;



    protected HMng() { }

    void Awake()
    {
        //SetAutoControlType();

        // 고정 프레임 vSync를 꺼야. 
        QualitySettings.vSyncCount = 0;

        // 고정 프레임 값
        Application.targetFrameRate = nFixedFrame;    
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }


    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
                     
    }


    /// <summary>
    /// 자동 컨틀롤 선택
    /// 
    /// OSXEditor	            Mac OS X상에서 동작하는 유니티 에디터 플레이어를 나타냅니다.
    /// OSXPlayer               Mac OS X에서 동작하는 플레이어를 나타냅니다.
    /// WindowsPlayer           Windows상에서 동작하는 플레이어를 나타냅니다.
    /// OSXWebPlayer            Mac OS X에서 동작하는 웹 플레이어를 나타냅니다.
    /// OSXDashboardPlayer      Mac OS X상에서 동작하는 Dashboard widget을 나타냅니다.
    /// WindowsWebPlayer        Windows상에서 동작하는 웹 플레이어를 나타냅니다.
    /// WindowsEditor           Windows상에서 동작하는 유니티 에디터를 나타냅니다.
    /// IPhonePlayer            iPhone에서 동작하는 플레이어를 나타냅니다.
    /// XBOX360                 XBOX360상에서 동작하는 플레이어를 나타냅니다.
    /// PS3 Play                Station 3에서 동작하는 플레이어를 나타냅니다.
    /// Android                 안드로이드 장치에서 동작하는 플레이어를 나타냅니다.
    /// LinuxPlayer             리눅스상에서 동작하는 플레이어를 나타냅니다.
    /// WebGLPlayer             WebGL에서 동작하는 플레이어를 나타냅니다.
    /// WSAPlayerX86            In the player on Windows Store Apps when CPU architecture is X86.
    /// WSAPlayerX64            In the player on Windows Store Apps when CPU architecture is X64.
    /// WSAPlayerARM            In the player on Windows Store Apps when CPU architecture is ARM.
    /// TizenPlayer             리눅스상에서 동작하는 플레이어를 나타냅니다.
    /// PSP2                    In the player on the PS Vita.
    /// PS4                     In the player on the Playstation 4.
    /// XboxOne                 In the player on Xbox One.
    /// SamsungTVPlayer         In the player on Samsung Smart TV.
    /// WiiU                    Windows상에서 동작하는 플레이어를 나타냅니다.
    /// tvOS                    iPhone에서 동작하는 플레이어를 나타냅니다.
    /// 
    /// </summary>
    //private void SetAutoControlType()
    //{
    //    if (Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.WindowsPlayer)
    //    {
    //        eControlType = E_CONTROL.MOUSE;
    //    }

    //    if (Application.platform == RuntimePlatform.Android ||
    //        Application.platform == RuntimePlatform.IPhonePlayer)
    //    {
    //        eControlType = E_CONTROL.JOYSTICK;
    //    }
    //}


    /// <summary>
    /// 소숫점 셋째 자리 이하는 반올림해요
    /// </summary>
    /// <param name="ValueV3"></param>
    /// <returns></returns>
    public Vector3 VectorRound(Vector3 ValueV3, int nDecimal = 1)
    {
        Vector3 CalcRound = Vector3.zero;

        //CalcRound.x = (Mathf.Round((ValueV3.x - 0.1f) * 10.0f) * 0.1f);
        //CalcRound.y = (Mathf.Round((ValueV3.y - 0.1f) * 10.0f) * 0.1f);

        CalcRound.x = (float)System.Math.Round((double)ValueV3.x, nDecimal);
        CalcRound.y = (float)System.Math.Round((double)ValueV3.y, nDecimal);
        CalcRound.z = 0.0f;

        return CalcRound;
    }


    /// <summary>
    /// 소숫점 이하자리 반올림
    /// </summary>
    /// <param name="value"></param>
    /// <param name="nDecimal"></param>
    /// <returns></returns>
    public float floatRound(float value, int nDecimal = 1)
    {
        float CalcRound = 0.0f;

        CalcRound = (float)System.Math.Round((double)value, nDecimal);

        return CalcRound;
    }

    /// <summary>
    /// range Unreal MapRangeClamp같은거유 ㅋㅋ
    /// </summary>
    /// <param name="fInput"></param>
    /// <param name="in_min"></param>
    /// <param name="in_max"></param>
    /// <param name="out_min"></param>
    /// <param name="out_max"></param>
    /// <param name="clamp"></param>
    /// <returns></returns>
    public float MapRangeInOut(float fInput, float in_min, float in_max, float out_min, float out_max, bool clamp = false)
    {
        if (clamp) fInput = Mathf.Max(in_min, Mathf.Min(fInput, in_max));
        return (fInput - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    /// <summary>
    /// z값만 0.0f로 변경합니다.
    /// </summary>
    /// <param name="Pos"></param>
    /// <returns></returns>
    public Vector3 ZtoZero(Vector3 Pos)
    {
        Pos.z = 0.0f;
        return Pos;        
    }



}
