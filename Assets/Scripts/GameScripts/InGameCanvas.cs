using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameCanvas : MonoBehaviour
{
    int totalCnt = 0;
    int accuracy = 0;
    bool isCorrect = false;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject requirementPanel;
    [SerializeField] GameObject requirementText;
    [SerializeField] GameObject requirementImg;
    [SerializeField] GameObject popupPanel;
    [SerializeField] List<GameObject> popups = new List<GameObject>();      // 팝업창 UI [확인중, 오답, 정답]
    [SerializeField] Text correctText;        // 정답 개수 보여줄 text
    int stageNum;

    void Awake() 
    {
        // 정답 팝업창 숨기기    
        popupPanel.SetActive(false);
        for(int i = 0; i < popups.Count; i++)
        {
            popups[i].SetActive(false);
        }
        stageNum = StageManager.Instance.stageNum;
        correctText = correctText.gameObject.GetComponent<Text>();
        requirementPanel.SetActive(false);
        menuPanel.SetActive(false);
    }

    // 말풍선 버튼 눌렀을 때 실행되는 함수
    public void OnClickedDialogueBtn()
    {
        SetRequirementImg();
        SetRequirementText();
        requirementPanel.SetActive(true);
    }

    void SetRequirementImg()
    {
        requirementImg.GetComponent<Image>().sprite = StageManager.Instance.GetStageData()[stageNum].GetRequestImg();
    }

    void SetRequirementText()
    {
        FileStream fs = new FileStream(StageManager.Instance.GetStageData()[stageNum].GetRequestPath(), FileMode.Open);
        StreamReader sr = new StreamReader(fs);

        string txt = sr.ReadToEnd();
        requirementText.GetComponent<Text>().text = txt;
        Debug.Log(txt);
        sr.Close();
        fs.Close();
    }

    // 메뉴 버튼 눌렀을 때 실행되는 함수
    public void OnClickedMenuBtn()
    {
        menuPanel.SetActive(true);
    }

    public void OnClickedCloseRequestBtn()
    {
        requirementPanel.SetActive(false);
    }
    public void OnClickedCloseMenuBtn()
    {
        menuPanel.SetActive(false);
    }
    public void OnClickedStageBtn()
    {
        SceneManager.LoadScene("1_StageScene");
    }

    public void ShowPopup()
    {
        // 정답 확인 중 팝업창 띄우기
        StartCoroutine(ShowPopupCoroutine());
    }

    // idx번재 팝업창 띄우는 함수
    IEnumerator ShowPopupCoroutine()
    {
        Debug.Log("코루틴함수 시작: 0");
        WaitForSeconds waitFor2Secodns = new WaitForSeconds(2f);
        WaitForSeconds waitFor1Secodns = new WaitForSeconds(1f);
        popupPanel.SetActive(true);
        popups[0].SetActive(true);
        yield return waitFor2Secodns;
        popups[0].SetActive(false);

        if(!isCorrect)  // 오답 팝업창 띄우기
        {
            // 오답 개수 표시
            correctText.text =  "작업물이 일치하지 않습니다. (" + accuracy + "/" + totalCnt + ")";
            popups[1].SetActive(true);
            yield return waitFor2Secodns;
            popups[1].SetActive(false);
        }
        else            // 정답 팝업창 띄우기
        {
            popups[2].SetActive(true);
            yield return waitFor2Secodns;
            popups[2].SetActive(false);
            yield return waitFor1Secodns;
            Debug.Log("스테이지 선택 화면으로 이동");
            SceneManager.LoadScene("1_StageScene");
        }  
        popupPanel.SetActive(false);      
    }
    
    // 정답 개수 설정하는 함수
    public void SetAccuracy(int count)
    {
        accuracy = count;
    }
    public void SetTotalCount(int count)
    {
        totalCnt = count; 
    }
    
    public void SetIsCorrect()
    {
        isCorrect = true;
    }
    public void SetIsNotCorrect()
    {
        isCorrect = false;
    }
}
