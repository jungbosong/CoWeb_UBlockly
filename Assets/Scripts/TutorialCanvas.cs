using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialCanvas : MonoBehaviour
{
    [SerializeField] List<Sprite> tutoImges = new List<Sprite>();
    [SerializeField] Image img;
    int cnt = -1;
    int maxCnt = 10;

    void Awake() 
    {
        img = img.transform.GetComponent<Image>();
    }

    public void OnClickedNextBtn()
    {
        cnt++;
        if(cnt < maxCnt)
        {
            img.sprite = tutoImges[cnt];
        }
        else 
        {
            SceneManager.LoadScene("UGUIDemo");
            StageManager.Instance.isFirst = false;
        }
    }
    public void OnClickedPreBtn()
    {
        cnt--;
        if(cnt >= 0)
        {
            img.sprite = tutoImges[cnt];
        }
        else
        {
            cnt = 0;
        }
    }
}
