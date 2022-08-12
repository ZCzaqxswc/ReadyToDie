using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRoot : MonoBehaviour
{
    /// <summary>
    /// 사용 중이냐
    /// </summary>
    public bool bUse = false;


    private void Awake()
    {

    }

    void Start()
    {

    }

    private void OnDestroy()
    {
        DestroyAll();
    }

    //[Virtual 함수]======================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================

    public virtual void Init()
    {
        bUse = false;

    }

    public virtual void UpdateMove() { }


    /// <summary>
    /// 활성화(SetAcvite, buse)
    /// </summary>
    public virtual void EnableCell()
    {
        bUse = true;
        gameObject.SetActive(true);
    }


    /// <summary>
    /// 비활성화
    /// </summary>
    public virtual void DisableCell()
    {

        this.Init();

        if (this != null)
            this.gameObject.SetActive(false);
    }

    /// <summary>
    /// 삭제할거 있음 삭제해요!
    /// </summary>
    public virtual void DestroyAll()
    {
        
    }




    //[사용자 정의 함수]==================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
      


    /// <summary>
    /// 업데이트를 실행할지 말지를 결정
    /// </summary>
    /// <returns></returns>
    protected bool Loop()
    {
        if (bUse && HMng.I.bGameStart && HMng.I.bPause == false)
        {
            return true;
        }
        return false;
    }


}
