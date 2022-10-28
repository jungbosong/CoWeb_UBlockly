using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonitorCanvas : MonoBehaviour
{
    [SerializeField] GameObject coWebBtn;
    [SerializeField] GameObject coMailBtn;
    [SerializeField] GameObject coWebPage;
    [SerializeField] GameObject coMailPage;
    [SerializeField] GameObject clientImg;
    [SerializeField] Text clientNameTxt;
    [SerializeField] Text clientAgeTxt;
    [SerializeField] Text clientGenderTxt;
    [SerializeField] Text clientAddressTxt;
    [SerializeField] Text clientCareerTxt;
    [SerializeField] GameObject requirementImg;
    [SerializeField] Text mailText;
    Color white, grey;
    int stageNum;
    //List<StageData> stages = new List<StageData>();

    void Awake() 
    {
        //stages = StageManager.Instance.GetStageData();
        ColorUtility.TryParseHtmlString("#FFFFFF", out white);
        ColorUtility.TryParseHtmlString("#D9D9D9", out grey);
    }

    public void SetMonitor()
    {
        Debug.Log("모니터 화면 설정");
        stageNum = StageManager.Instance.stageNum;
        SetClientInfo();
        SetRequirementImg();
        SetMailText();
        OnClickedCoWebBtn();
    }

    // CoWeb페이지 버튼 눌렀을때 실행되는 함수
    public void OnClickedCoWebBtn()
    {
        coMailPage.SetActive(false);
        coWebPage.SetActive(true);
        coWebBtn.GetComponent<Image>().color = white;
        coMailBtn.GetComponent<Image>().color = grey;
    }

    // CoMail페이지 버튼, 의뢰보기 버튼 눌렀을 때 실행되는 함수
    public void OnClickedCoMailBtn()
    {
        coMailPage.SetActive(true);
        coWebBtn.GetComponent<Image>().color = grey;
        coMailBtn.GetComponent<Image>().color = white;
    }
    
    // 개발시작 버튼 눌렀을 때 실행되는 함수
    public void OnClickedStartDevBtn()
    {
        SceneManager.LoadScene("UGUIDemo");
    }

    // 현재 스테이지 번호에 따라 클라이언트 정보 수정하는 함수
    void SetClientInfo()
    {
        SetClientImg();
        SetClientNameTxt();
        SetClientAgeTxt();
        SetClientAddressTxt();
        SetClientGenderTxt();
        SetClientCareerTxt();
    }
    void SetClientImg()
    {
        clientImg.GetComponent<Image>().sprite = StageManager.Instance.GetStageData()[stageNum].GetClientImg();
    }
    void SetClientNameTxt()
    {
        clientNameTxt.GetComponent<Text>().text = StageManager.Instance.GetStageData()[stageNum].GetClientName();
    }
    void SetClientAgeTxt()
    {
        clientAgeTxt.GetComponent<Text>().text = StageManager.Instance.GetStageData()[stageNum].GetClientAge();
    }
    void SetClientGenderTxt()
    {
        clientGenderTxt.GetComponent<Text>().text = StageManager.Instance.GetStageData()[stageNum].GetClientGender();
    }

    void SetClientAddressTxt()
    {
        clientAddressTxt.GetComponent<Text>().text = StageManager.Instance.GetStageData()[stageNum].GetClientAddress();
    }

    void SetClientCareerTxt()
    {
        clientCareerTxt.GetComponent<Text>().text = StageManager.Instance.GetStageData()[stageNum].GetClientCareer();
    }

    // 현재 스테이지 번호에 따라 메일 내용 수정하는 함수
    void SetMailText()
    {
        mailText.GetComponent<Text>().text = StageManager.Instance.GetStageData()[stageNum].GetRequest().text;
    }

    // 현재 스테이지 번호에 따라 요구사항 이미지 변경하는 함수
    void SetRequirementImg()
    {
        requirementImg.GetComponent<Image>().sprite = StageManager.Instance.GetStageData()[stageNum].GetRequestImg();
    }
    
    
}
