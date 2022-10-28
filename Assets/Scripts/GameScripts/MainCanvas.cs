using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour
{
    // Game Start 버튼을 눌렀을 때 실행되는 함수
    public void OnClickedGameStartBtn()
    {
        SceneManager.LoadScene("1_StageScene");
    }
    // Quit 버튼을 눌렀을 때 실행되는 함수
    public void OnClickedQuitButton()
    {
        Application.Quit();
    }
}
