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
        ShowStageInfo();
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
