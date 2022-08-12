using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scr_StageSelect : MonoBehaviour
{
    public Animator transition;
    public Text StageText;

    void Start()
    {
        if(!GameObject.Find("GameManager"))
        {
            SceneManager.LoadScene("1_LogoScene");
        }
        //Scr_StageManager.instance.Stage = 1;
    }
    public void StageChoose(int Level)
    {
        transition.SetTrigger("Close");
        Scr_StageManager.instance.StartLevel(Level);
    }

    public void FieldUp()
    {
         if(Scr_StageManager.instance.Stage < 2)
        {
            Scr_StageManager.instance.Stage++;
            StageTextChange(Scr_StageManager.instance.Stage);
        }
    }
    public void FieldDown()
    {
        if(Scr_StageManager.instance.Stage > 1)
        {
            Scr_StageManager.instance.Stage--;
            StageTextChange(Scr_StageManager.instance.Stage);
        }
    }


    public void StageTextChange(int _Stage)
    {
        switch(_Stage)
        {
            case 1:
            StageText.text = "Escape from Lab City";
            break;

            case 2:
            StageText.text = "Snowy Field";
            break;

            default:
            StageText.text = "";
            break;
        }
    }
}
