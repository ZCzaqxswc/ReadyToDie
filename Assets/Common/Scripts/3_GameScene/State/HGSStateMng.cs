using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MHomiLibrary;
using TMPro;

public class HGSStateMng : HSingletonScene<HGSStateMng>
{
    protected HGSStateMng() { }

    /// <summary>
    /// 스테이지 확인 버튼내 text
    /// </summary>
    public TextMeshProUGUI StageText;
    public int nCurStage = 1;
    

    
    void Awake()
    {
        cSceneList = new Dictionary<string, HState>();

        for (int i = 0; i < SceneList.Count; i++)
            cSceneList.Add(GetClassName(SceneList[i].ToString()), SceneList[i]);
    }

    void Start()
    {
        ChangeScene("HGSStage_1");
    }

    public void Update()
    {
        base.Update();
    }

    private void OnDestroy()
    {

    }


    public void ChangeStage()
    {
        nCurStage++;

        if (nCurStage > SceneList.Count)
            nCurStage = 1;


        StageText.text = "Stage " + nCurStage;

        ChangeScene("HGSStage_" + nCurStage);
    }
}
