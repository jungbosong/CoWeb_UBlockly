using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Tag;

public class AnswerChecker : MonoBehaviour
{
    [SerializeField] GameObject inGameCanvasObj;
    InGameCanvas inGameCanvas;
    void Awake() 
    {
        inGameCanvas = inGameCanvasObj.GetComponent<InGameCanvas>();
    }

    // 제출 버튼 눌렀을 때 실행되는 함수
    public void OnClickedSubmitBtn()
    {
        int stageNum = StageManager.Instance.stageNum;
        string correctjsonCode = StageManager.Instance.GetStageData()[stageNum].GetCorrectCode().text;

        // 정답 json코드 읽기
        List<TagInfo> correctCode = JsonUtility.FromJson<TagData>(correctjsonCode).tagInfoList;
        Debug.Log("correct Code: ");
        printReadedCode(correctCode);
        
        // 블록 코딩으로 만들어진 json코드 읽기    
        List<TagInfo> answerCode = ReadJson(Application.persistentDataPath + "/index.json").tagInfoList;
        Debug.Log("answer Code: ");
        printReadedCode(answerCode);

        // 코드 일치 여부 확인
        if(answerCode.Count <= correctCode.Count)
        {
            int accuracy = 0;
            for(int i = 0; i < answerCode.Count; i++)
            {
                //Debug.Log("i: " + i + " answerCode[i]: " + answerCode[i].tagType);
                //Debug.Log("i: " + i + " correctCode[i]: " + correctCode[i].tagType);
                if(!correctCode[i].tagType.Equals(answerCode[i].tagType))    // tagType 확인
                {
                    //Debug.Log("코드가 일치하지 않습니다! 사유: 타입");
                    inGameCanvas.SetIsNotCorrect();
                    continue;
                }
                if(!correctCode[i].tagName.Equals(answerCode[i].tagName))    // tagName 일치
                {
                    //Debug.Log("코드가 일치하지 않습니다! 사유: 이름");
                    inGameCanvas.SetIsNotCorrect();
                    continue;
                }
                if(!correctCode[i].data.Equals(answerCode[i].data))    // data 일치
                {
                    //Debug.Log("코드가 일치하지 않습니다! 사유: data");
                    inGameCanvas.SetIsNotCorrect();
                    continue;
                }
                if(!correctCode[i].property.Equals(answerCode[i].property))    // property 일치  
                {
                    //Debug.Log("코드가 일치하지 않습니다! 사유: property");
                    inGameCanvas.SetIsNotCorrect();
                    continue;
                } 
                accuracy++;
            } 
            if(90 <= (float)accuracy/correctCode.Count*100)
            {
                inGameCanvas.SetIsCorrect();
                StageManager.Instance.AddStageNum();
                StageManager.Instance.OpenStage();
            }
            inGameCanvas.SetAccuracy(accuracy);            
        }
        inGameCanvas.SetTotalCount(correctCode.Count);
        inGameCanvas.ShowPopup();
    }
    
    // json코드 읽는 함수
    TagData ReadJson(string path)
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<TagData>(json);
    }

    void printReadedCode(List<TagInfo>  code)
    {        
        for(int i = 0; i < code.Count; i++)
        {
            Debug.Log("Type: " + code[i].tagType);
            Debug.Log("Name: " + code[i].tagName);
            Debug.Log("data: " + code[i].data);
            Debug.Log("property: " + code[i].property);
        }
    }
}
