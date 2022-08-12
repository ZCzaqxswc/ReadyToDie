using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scr_LevelButton : MonoBehaviour
{
    [SerializeField]
    private bool Pre_Clear;
    [SerializeField]
    private int Stage;
    [SerializeField]
    private int Level;

    public Animator transition;
    public Sprite Clear_Spr;
    Image Btn;

    void Awake()
    {
        Btn = GetComponent<Image>();
        ClearCheck();
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void OnEnable()
    {
        if(Pre_Clear)
        {
            Btn.sprite = Clear_Spr;
        }
    }

    public void ClearCheck()
    {
        if(Stage == 1 && Level ==1)
        {
            Pre_Clear = true;
        }
        else if(Level == 1)
        {
            Scr_StageManager.instance.ClearCheak(Stage-1, 5 , out Pre_Clear);
        }
        else
        {
            Scr_StageManager.instance.ClearCheak(Stage , Level-1 , out Pre_Clear);
        }
    }


    public void MoveLevel()
    {
        if(Pre_Clear)
        {
            Scr_StageManager.instance.Stage = Stage;
            Scr_StageManager.instance.Level = Level;
            StartCoroutine(LoadLevel());
        }
    }


    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Close");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Stage"+Stage +"_" + Level);
    }
}
