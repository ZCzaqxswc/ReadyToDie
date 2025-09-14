using System.Collections;
using System.Collections.Generic;
using MHomiLibrary;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class LogoScene : MonoBehaviour
{   
    public Animator transition;
    void Start()
    {

    }

    void Update()
    {

    }

    public void GotoLobbyScene()
    {
        transition.SetTrigger("Close");
        Scr_StageManager.instance.GoLobby();
    }

}
