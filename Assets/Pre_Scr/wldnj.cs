using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class wldnj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pan;
    public Animator transition;
    public int pointerID;


    void Start()
    {
        #if UNITY_EDITOR
        pointerID = -1;
        #elif UNITY_ANDROID
        pointerID = 0;
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject(pointerID))
            {
                return;
            }
            else
            {
                //Pan.SetActive(false);
            }
        }
    }

    public void TestMove (int a)
    {
        StartCoroutine(LoadNextLevel(a));
    }

    public void ClaerPan()
    {
        Pan.SetActive(false);
    }
    public void PopupPan()
    {
        Pan.SetActive(true);
    }

    IEnumerator LoadNextLevel(int _a)
    {
        transition.SetTrigger("Close");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Stage1_" + _a);
    }
}

