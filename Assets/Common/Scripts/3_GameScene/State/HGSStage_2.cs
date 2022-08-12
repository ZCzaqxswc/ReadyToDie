using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MHomiLibrary;

public class HGSStage_2 : HState
{
    public GameObject Map;
    public GameObject Target;
    public override void Enter(params object[] oParams)
    {
        //한번만 호출
        Map.SetActive(true);
        Debug.Log("[HGSStage_2 Enter]");
        GameObject[] Target = GameObject.FindGameObjectsWithTag("FireDie");
        for (int i = 0; i < Target.Length; i++)
        {
           Destroy(Target[i]);
        }
        
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