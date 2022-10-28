using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageCanvas : MonoBehaviour
{
    // 월 ~ 금 스테이지 버튼 객체
    [SerializeField] List<GameObject> stageBtns = new List<GameObject>();
    // 스테이지 버튼이 클릭 됬을 때 이미지
    [SerializeField] Sprite clickedImg;
    // 스테이지 버튼이 클릭 안 됬을 때 이미지
    [SerializeField] Sprite notClickedImg;
    // monitorCanvas 객체
    [SerializeField] GameObject monitorCanvas;
    // 열리지 않은 스테이지 선택했을 때 뜨는 팝업 객체
    [SerializeField] GameObject notOpenedPopup;
    // 준비 중인 스테이지 선택했을 때 뜨는 팝업 객체
    [SerializeField] GameObject preparingPopup;
    // StageManager.cs에서 관리되는 스테이지 정보를 List로 저장하는 변수
    List<StageData> stages = new List<StageData>();

    void Start() 
    {
        stages = StageManager.Instance.GetStageData();
        SetStageBtnUI();
        notOpenedPopup.SetActive(false);
        preparingPopup.SetActive(false);
        monitorCanvas.SetActive(false);
    }

    void SetStageBtnUI()
    {
        SetStageBtnImg();
        SetStageClientImg();
        SetStageBtnName();
        SetBtnClick();
    }

    void SetStageBtnImg()
    {
        for(int i = 0; i < stageBtns.Count; i++)
        {
            stageBtns[i].GetComponent<Button>().GetComponent<Image>().sprite = notClickedImg;
        }
    }

    void SetStageClientImg()
    {
        for(int i = 0; i < stageBtns.Count; i++)
        {
            stageBtns[i].transform.GetChild(1).GetComponent<Image>().sprite = stages[i].GetClientImg();
        }
    }

    void SetStageBtnName()
    {
        for(int i = 0; i < stageBtns.Count; i++)
        {
            if(!stages[i].GetIsLocked())
            {
                stageBtns[i].transform.GetChild(2).GetComponent<Text>().text = stages[i].GetClientName();
            }
            else 
            {
                stageBtns[i].transform.GetChild(2).GetComponent<Text>().text = "???";
            }
        }
    }

    void SetBtnClick()
    {
        for(int i = 0; i < stageBtns.Count; i++)
        {
            int tmp = i;
            stageBtns[i].GetComponent<Button>().onClick.AddListener(() => OnClickedStageBtn(tmp));
        }
    }

    void OnClickedStageBtn(int btnNum)
    {
        SetStageBtnImg();
        stageBtns[btnNum].GetComponent<Button>().GetComponent<Image>().sprite = clickedImg;
        if(btnNum == 4)
        {
            Debug.Log("아직 준비중인 스테이지입니다.");
            StartCoroutine(ShowPopup(preparingPopup));
        }
        else
        {
            if(!stages[btnNum].GetIsLocked()) 
            {
                StageManager.Instance.stageNum = btnNum;
                Debug.Log("Start Stage_" + btnNum);
                monitorCanvas.GetComponent<MonitorCanvas>().SetMonitor();
                monitorCanvas.SetActive(true);
                Debug.Log("monitorCanvas.SetActive(true)");
            }
            else
            {
                Debug.Log("It's Locked Stage");
                StartCoroutine(ShowPopup(notOpenedPopup));
            }
        }
    }

    IEnumerator ShowPopup(GameObject popup)
    {
        WaitForSeconds waitForSecodns = new WaitForSeconds(1.5f);
        popup.SetActive(true);
        yield return waitForSecodns;
        popup.SetActive(false);
    }
}
