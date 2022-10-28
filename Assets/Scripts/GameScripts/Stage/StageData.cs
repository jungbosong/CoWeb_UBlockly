using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageData : MonoBehaviour
{
    [SerializeField] int stageNum;
    [SerializeField] bool isLocked;
    [SerializeField] Sprite clientImg;
    [SerializeField] string clientName;
    [SerializeField] string clientAge;
    [SerializeField] string clientGender;
    [SerializeField] string clientAddress;
    [SerializeField] string clientCareer;
    [SerializeField] string correctCodePath;
    [SerializeField] Sprite requestImg;
    [SerializeField] string requestPath;

    public int GetStageNum()
    {
        return stageNum;
    }

    public bool GetIsLocked()
    {
        return isLocked;
    }

    public Sprite GetClientImg()
    {
        return clientImg;
    }

    public string GetClientName()
    {
        return clientName;
    }
    public string GetClientAge()
    {
        return clientAge;
    }
    public string GetClientGender()
    {
        return clientGender;
    }
    public string GetClientAddress()
    {
        return clientAddress;
    }
    public string GetClientCareer()
    {
        return clientCareer;
    }

    public string GetCorrectCodePath()
    {
        return correctCodePath;
    }
    public Sprite GetRequestImg()
    {
        return requestImg;
    }

    public string GetRequestPath()
    {
        return requestPath;
    }

    public void SetIsLocked(bool locked)
    {
        isLocked = locked;
    }
}
