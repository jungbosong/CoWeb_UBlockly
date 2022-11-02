using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebView : MonoBehaviour
{
    private WebViewObject webViewObject = null;
    private WebViewObject popupWebViewObj = null;
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

    public void Hide()
    {
        if (webViewObject != null)
        {
            //Destroy(webViewObject);
            webViewObject.SetVisibility(false);
        }
    }
    public void StartWebView()
    {
        if(webViewObject != null)
        {
            Destroy(webViewObject);
            webViewObject = null;
            StartWebView();
        }
        else
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
                /*webViewObject.SetVisibility(true);
                // Margin: 좌, 상, 우, 하 
                webViewObject.SetMargins((int)(Screen.width * 0.7), (int)(Screen.height * 0.55), 0, 0);*/
                ShowWebView();
            }
            catch( System.Exception e)
            {
                print($"WebView Error : {e}");
            }
        }
    }

    public void ShowWebView()
    {
        if(webViewObject != null)
        {
            //webViewObject.SetVisibility(true);
            Debug.Log("ShowWebView");
            webViewObject.SetMargins((int)(Screen.width * 0.7), (int)(Screen.height * 0.55), 0, 0);
            webViewObject.SetVisibility(true);
        }
        /*else if(!isOpenedWebView)
        {
            StartWebView();
        }*/
    }

    public void StartPopupWebView()
    {
        /*string URL = Application.persistentDataPath + "/index.htm";
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
        }*/
        if(webViewObject != null)
        {
            Debug.Log("ShowPopupWebView");
            webViewObject.SetMargins((int)(Screen.width * 0.51), (int)(Screen.height * 0.5), (int)(Screen.width * 0.1), (int)(Screen.height * 0.1));
            webViewObject.SetVisibility(true);
        }
    }
    
    /*public void ShowPopupWebView()
    {
        
        if(popupWebViewObj != null)
        {
            popupWebViewObj.SetVisibility(true);
        }
        else
        {
            StartPopupWebView();
        }
        
    }

    public void HidePopupWebView()
    {
        if (popupWebViewObj != null)
        {
            Debug.Log("Destroy PopupWebViewObj");
            Destroy(popupWebViewObj);
            //popupWebViewObj.SetVisibility(false);

            if(isOpenedWebView) ShowWebView();
        }
    }*/
}
