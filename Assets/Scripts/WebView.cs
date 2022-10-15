using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebView : MonoBehaviour
{
    private WebViewObject webViewObject;
    // 싱글톤
    private static WebView instance = null;
    void Awake() 
    { 
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            if(instance != this) {
                Destroy(this.gameObject);
            }
        }
    }

    public static WebView Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKey(KeyCode.Escape))
            {
                // 뒤 로 가 기, esc 버 튼 
                Hide();
                return;
            }
        }
    }

    public void Show()
    {
        StartWebView();
    }

    public void Hide()
    {
        // 뒤 로 가 기, esc 버 튼 
        if (webViewObject != null)
        {
            Destroy(webViewObject);
        }
    }
    public void StartWebView()
    {
        Debug.Log("called StartWebView");
        string URL = Application.persistentDataPath + "/index.htm";
        try
        {
            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
            webViewObject.Init((msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
            });

            webViewObject.LoadURL(URL);
            webViewObject.SetVisibility(true);
            webViewObject.SetMargins((int)(Screen.width * 0.7), 0, 0, 0);
        }
        catch( System.Exception e)
        {
            print($"WebView Error : {e}");
        }
    }
}
