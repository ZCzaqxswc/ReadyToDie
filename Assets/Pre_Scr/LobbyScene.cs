using System.Collections;
using System.Collections.Generic;
using MHomiLibrary;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class LobbyScene : MonoBehaviour
{   
    public GameObject[] StagePanel;

    protected LobbyScene() { }

    void Start()
    {

    }

    void Update()
    {

    }

    public void StagePanelActive(int A)
    {
        StagePanel[A].gameObject.SetActive(true);
    }

    public void PanelFalse(int A)
    {
        StagePanel[A].gameObject.SetActive(false);
    }

    public void GotoGameScene()
    {
        SceneManager.LoadScene("3_GameScene");
    }
}
