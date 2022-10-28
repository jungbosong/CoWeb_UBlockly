using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageData : MonoBehaviour
{
    [SerializeField] int stageNum;  // 스테이지 번호
    [SerializeField] bool isLocked; // 잠김 여부
    [SerializeField] Sprite clientImg;  // 의뢰인 사진
    [SerializeField] string clientName; // 의뢰인 이름
    [SerializeField] string clientAge;  // 의뢰인 나이
    [SerializeField] string clientGender; // 의뢰인 성별
    [SerializeField] string clientAddress;  // 의뢰인 주소
    [SerializeField] string clientCareer;   // 의뢰인 작업
    [SerializeField] TextAsset correctCode;  // 정답 코드 경로
    [SerializeField] Sprite requestImg; // 요구사항 결과물
    [SerializeField] TextAsset request;    // 요구사항 내용 경로

    public int GetStageNum()    // 스테이지 번호 반환 함수
    {
        return stageNum;
    }
    public bool GetIsLocked()   // 잠김 여부 반환 함수
    {
        return isLocked;
    }
    public Sprite GetClientImg() // 의뢰인 이미지 반환 함수
    {
        return clientImg;
    }
    public string GetClientName() // 의뢰인 이름 반환 함수
    {
        return clientName;
    }
    public string GetClientAge() // 의뢰인 나이 반환 함수
    {
        return clientAge;
    }
    public string GetClientGender() // 의뢰인 성별 반환 함수
    {
        return clientGender;
    }
    public string GetClientAddress() // 의뢰인 주소 반환 함수
    {
        return clientAddress;
    }
    public string GetClientCareer() // 의뢰인 직업 반환 함수
    {
        return clientCareer;
    }
    public TextAsset GetCorrectCode() // 정답 코드 경로 반환 함수
    {
        return correctCode;
    }
    public Sprite GetRequestImg() // 요구사항 결과물 이미지 반환 함수
    {
        return requestImg;
    }
    public TextAsset GetRequest() // 요구사항 내용 경로 반환 함수
    {
        return request;
    }
    public void SetIsLocked(bool locked) // 잠김 여부 locked로 설정하는 함수
    {
        isLocked = locked;
    }
}
