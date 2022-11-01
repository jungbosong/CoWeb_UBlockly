using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebView : MonoBehaviour
{
    private WebViewObject webViewObject;
    private WebViewObject popupWebViewObj;
    private bool isOpenedWebView = false;
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
        if (webViewObject != null)
        {
            Destroy(webViewObject);
        }
    }
    public void StartWebView()
    {
        Debug.Log("called StartWebView");
        string URL = Application.persistentDataPath + "/index.htm";
        isOpenedWebView = true;
        try
        {
            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
            webViewObject.Init((msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
            });

            webViewObject.LoadURL(URL);
            webViewObject.SetVisibility(true);
            // Margin: 좌, 상, 우, 하 
            webViewObject.SetMargins((int)(Screen.width * 0.7), (int)(Screen.height * 0.55), 0, 0);
        }
        catch( System.Exception e)
        {
            print($"WebView Error : {e}");
        }
    }

    public void StartPopupWebView()
    {
        string URL = Application.persistentDataPath + "/index.htm";
        try
        {
            Hide();
            popupWebViewObj = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
            popupWebViewObj.Init((msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
            });

            popupWebViewObj.LoadURL(URL);
            popupWebViewObj.SetVisibility(true);
            // Margin: 좌, 상, 우, 하 
            popupWebViewObj.SetMargins((int)(Screen.width * 0.51), (int)(Screen.height * 0.5), (int)(Screen.width * 0.1), (int)(Screen.height * 0.1));
        }
        catch( System.Exception e)
        {
            print($"WebView Error : {e}");
        }
    }

    public void HidePopupWebView()
    {
        if (popupWebViewObj != null)
        {
            Debug.Log("Destroy PopupWebViewObj");
            Destroy(popupWebViewObj);

            if(isOpenedWebView) StartWebView();
        }
    }
}
