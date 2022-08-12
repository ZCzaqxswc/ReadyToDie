using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MHomiLibrary;

public class HGSStage_1 : HState
{
    public GameObject Map;
    public override void Enter(params object[] oParams)
    {
        //한번만 호출
        Debug.Log("[HGSStage_1 Enter]");
    }

    public override void Execute()
    {
        Debug.Log("[HGSStage_1 Execute]");
        
    }

    public override void Exit()
    {
        Map.SetActive(false);
    }

    void OnDestroy()
    {

    }
}