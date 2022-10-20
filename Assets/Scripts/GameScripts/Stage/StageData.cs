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
    [SerializeField] string correctCodePath;
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

    public string GetCorrectCodePath()
    {
        return correctCodePath;
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
