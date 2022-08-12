using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MHomiLibrary;
using System.Runtime.InteropServices;

public class IntroSecne : HSingleton<IntroSecne>
{
    void Start()
    {
      
    }

    void Update()
    {
        
    }

    public void GoToLogoScene()
    {
        SceneManager.LoadScene("1_LogoScene");
    }
}
