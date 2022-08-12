﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//1.출력 끄기
#pragma warning disable CS0618
#pragma warning disable CS0105
#pragma warning disable CS0414

//2.출력 켜기
//#pragma warning restore CS0067
//#pragma warning restore 649
//#pragma warning restore 67, CS0649 //쉼표로 연결 가능


public class HFps : MonoBehaviour
{
    float deltaTime = 0.0f;

    GUIStyle style;
    Rect rect;
    float msec;
    float fps;
    float worstFps = 100f;
    string text;

    void Awake()
    {
        int w = Screen.width, h = Screen.height;

        rect = new Rect(50, 0, w, h * 4 / 100);

        style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        //style.fontSize = h * 4 / 100;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = Color.cyan;

        StartCoroutine("worstReset");
    }


    IEnumerator worstReset() //코루틴으로 15초 간격으로 최저 프레임 리셋해줌.
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            worstFps = 100f;
        }
    }


    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()//소스로 GUI 표시.
    {

        msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;  //초당 프레임 - 1초에

        if (fps < worstFps)  //새로운 최저 fps가 나왔다면 worstFps 바꿔줌.
            worstFps = fps;
        text = msec.ToString("F1") + "ms (" + fps.ToString("F1") + ") //worst : " + worstFps.ToString("F1");
        //GUI.Label(rect, text, style);
    }    
}
