using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;
    private List<StageData> stages = new List<StageData>();
    [SerializeField] GameObject stageInfo;
    public int stageNum{get; set;}  // 현재 진행 중인 스테이지 번호
    int maxStageNum = 4;   // 마지막 스테이지 번호
    public Dictionary<int, List<string>> openTags{get; private set;}
    void Awake() 
    {
        if(Instance == null)    
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
        InitStageInfo();
        InitOpenTags();
        ShowStageInfo();
    }

    void InitOpenTags()
    {
        openTags = new Dictionary<int, List<string>>();
        openTags.Add(0, new List<string>());
        openTags[0].Add("space");
        openTags[0].Add("space_html");
        openTags[0].Add("text2_text");

        openTags.Add(1, new List<string>());
        openTags[1].Add("text2_h1");
        openTags[1].Add("text2_b");
        openTags[1].Add("text2_br");
        openTags[1].Add("text2_a");

        openTags.Add(2, new List<string>());
        openTags[2].Add("imageForm_img");
        openTags[2].Add("imageForm_form");
        openTags[2].Add("imageForm_label");
        openTags[2].Add("imageForm_input");
        openTags[2].Add("imageForm_button");

        openTags.Add(3, new List<string>());
        openTags[3].Add("text2_p");
        openTags[3].Add("text2_ul");
        openTags[3].Add("text2_li");
        
    }

    void InitStageInfo()
    {
        for(int i = 0; i < stageInfo.transform.childCount; i++)
        {
            stages.Add(new StageData());
            stages[i] = stageInfo.transform.GetChild(i).GetComponent<StageData>();
        }
    }
    public void AddStageNum()
    {
        stageNum++;
        if(stageNum >= maxStageNum)
        {
            stageNum = 4;
        }
    }

    public void OpenStage()
    {
        stages[stageNum].SetIsLocked(false);
    }

    void ShowStageInfo()
    {
        for(int i = 0; i < stages.Count; i++)
        {
            Debug.Log("stage_" + i + "_Num: " + stages[i].GetStageNum());
            Debug.Log("stage_" + i + "_islcoekd: " + stages[i].GetIsLocked());
        }
    }

    public List<StageData> GetStageData()
    {
        return stages;
    }
    
}
