using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageCanvas : MonoBehaviour
{
    [SerializeField] List<GameObject> stageBtns = new List<GameObject>();
    [SerializeField] Sprite clickedImg;
    [SerializeField] Sprite notClickedImg;
    [SerializeField] GameObject notOpenedPopup;
    List<StageData> stages = new List<StageData>();

    void Start() 
    {
        stages = StageManager.Instance.GetStageData();
        SetStageBtnUI();
        notOpenedPopup.SetActive(false);
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
        if(!stages[btnNum].GetIsLocked()) 
        {
            StageManager.Instance.stageNum = btnNum;
            Debug.Log("Start Stage_" + btnNum);
            SceneManager.LoadScene("UGUIDemo");
        }
        else
        {
            Debug.Log("It's Locked Stage");
            notOpenedPopup.SetActive(true);
            StartCoroutine(CloseNOpnedPopup());
        }
    }

    IEnumerator CloseNOpnedPopup()
    {
        WaitForSeconds waitForSecodns = new WaitForSeconds(1.5f);
        yield return waitForSecodns;
        notOpenedPopup.SetActive(false);
    }
}
