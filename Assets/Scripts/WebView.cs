using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebView : MonoBehaviour
{
    [HideInInspector]
    public string URL = "https://www.naver.com";
    private WebViewObject webViewObject;

    void Start()
    {
        StartWebView();
    }

    // Update is called once per frame
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

    public void Show(string url)
    {
        //gameObject.Show();

        URL = url;
        StartWebView();
    }

    public void Hide()
    {
        // 뒤 로 가 기, esc 버 튼 
        URL = string.Empty;

        if (webViewObject != null)
        {
            Destroy(webViewObject);
        }

        //gameObject.Hide();
    }
    public void StartWebView()
    {

        string strUrl = URL;  

        try
        {
            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
            webViewObject.Init((msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
            });

            webViewObject.LoadURL(strUrl);
            webViewObject.SetVisibility(true);
            webViewObject.SetMargins((int)(Screen.width * 0.7), 0, 0, 0);
        }
        catch( System.Exception e)
        {
            print($"WebView Error : {e}");
        }
    }
}
