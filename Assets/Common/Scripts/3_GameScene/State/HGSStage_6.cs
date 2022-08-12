using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MHomiLibrary;

public class HGSStage_6 : HState
{
    public override void Enter(params object[] oParams)
    {
        //한번만 호출
        Debug.Log("[HGSStage_6 Enter]");
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