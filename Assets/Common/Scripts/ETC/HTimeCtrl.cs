using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTimeCtrl 
{
    /// <summary>
    /// TimeCheck함수 실행 유무
    /// </summary>
    private bool bTimeCheck = true;

    /// <summary>
    /// 누적 타임
    /// </summary>
    private double dAddTime = 0.0f;

    /// <summary>
    /// 타임 체크 
    /// upate내에서 호출하세요~
    /// </summary>
    /// <param name="fLimitTime"></param>
    /// <param name="bOnlyOne"></param>
    /// <returns></returns>
    public bool TimeCheck(float fLimitTime, bool bOnlyOne = false)
    {
        if (bTimeCheck)
        {
            dAddTime += Time.deltaTime;

            if (dAddTime >= fLimitTime)
            {
                if(bOnlyOne == true)
                    bTimeCheck = false;
                
                dAddTime = 0.0f;

                return true;
            }
            else
                return false;
        }
        return false;
    }

    /// <summary>
    /// 타임 재시작
    /// </summary>
    public void ReStartTimeCheck()
    {
        bTimeCheck = true;
        dAddTime = 0.0f;
    }
}
