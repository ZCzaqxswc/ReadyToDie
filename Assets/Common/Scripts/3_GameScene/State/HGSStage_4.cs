using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MHomiLibrary;

public class HGSStage_4 : HState
{
    public override void Enter(params object[] oParams)
    {
        //한번만 호출
        Debug.Log("[HGSStage_4 Enter]");
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }

    void OnDestroy()
    {

    }
}