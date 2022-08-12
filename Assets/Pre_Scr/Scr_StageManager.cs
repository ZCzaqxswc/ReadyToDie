using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using Newtonsoft.Json;

[Serializable]
public class SaveData
{
    public bool StageClear;
    public int Stage;
    public int Level;
    //public int Star;
    public SaveData(bool A_Clear , int A_Stage , int A_Level)
    {

        //별갯수는 나중에 구현
        StageClear = A_Clear;
        Stage = A_Stage;
        Level = A_Level;
        //Star = A_Star;
    }
}

public class Scr_StageManager : MonoBehaviour
{
    public static Scr_StageManager instance;
    private List<SaveData> DataInfo;

    public int Stage;
    public int Level;

    // Start is called before the first frame update

    void Awake()
    {
        if(!instance)
        {
            instance = this;
            
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        DataInfo = new List<SaveData>();
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel(int A_Level)
    {
        Level = A_Level;
        StartCoroutine(LoadNextLevel());
    }

    public void ClearStage()
    {
        ClearSave(Stage , Level);
        Level++;
        if(Level == 6)
        {
            if(Stage == 3)
            {
                StartCoroutine(GoToLobby());
                return;
            }
                Stage++;
                Level=1;
        }
        StartCoroutine(LoadNextLevel());
    }

    public void GoLobby()
    {
        Stage =0;
        Level = 0;
        StartCoroutine(GoToLobby());
    }

    public void Load()
    {
        string text = "";
		if (File.Exists(Path.Combine(Application.persistentDataPath, "Save.json")))
		{
			text = File.ReadAllText(Path.Combine(Application.persistentDataPath, "Save.json"));
			Debug.Log(text);
			DataInfo = JsonConvert.DeserializeObject<List<SaveData>>(text);
		}
    }

    public void ClearSave(int A_Stage , int A_Level)
    {
        int var = -1;
        ///처음클리어인지 확인
        for(int i = 0; i<DataInfo.Count; i++)
        {
            if(DataInfo[i].Stage == A_Stage && DataInfo[i].Level == A_Level)
            {
                var = i;
            }
        }

///////////처음클리어가 아닐때
        if(var != -1)
        {
            return;
        }
        else
        {
            SaveData DD = new SaveData(true , A_Stage , A_Level);
            DataInfo.Add(DD);
        }
        string DB = JsonConvert.SerializeObject(DataInfo,Formatting.Indented);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "Save.json"), DB);

    }


    public void ClearCheak(int A_Stage , int A_Level , out bool preClear)
    {
        preClear = false;
        int num = 0;
        while(true)
        {
            if(num < DataInfo.Count)
            {
                if(DataInfo[num].Stage == A_Stage && DataInfo[num].Level == A_Level)
                {
                    break;
                }
                num++;
                continue;
            }
            return;
        }
        preClear = DataInfo[num].StageClear;
    }









    public void ChFun()
    {
        int var = -1;
        for(int i=0; i<DataInfo.Count; i++)
        {
            var = i;
            Debug.Log(i + "번째 클래스고");
        
        
            if(var != -1)
            {
                Debug.Log(DataInfo[i].Stage +"번쨰 스테이지고"+ DataInfo[i].Level+ "번쨰 레벨이고");
                Debug.Log( i+"값은" + DataInfo[var].StageClear + "이야!");
            }
            else
            {
                Debug.Log("클리어한적이 없네?");
            }
        }
    }


















    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1f);
        if(Level > 5)
        {
            Level =1;
            Stage++;
        }
        if(Stage == 4)
        {
             SceneManager.LoadScene("2_LobbyScene");
        }
        else
        SceneManager.LoadScene("Stage" + Stage + "_" + Level );
    }

    IEnumerator GoToLobby()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("2_LobbyScene");
    }

}
