using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class HtmlCodeMaker : MonoBehaviour
{
    public static HtmlCodeMaker Instance = null;
    private StringBuilder strBuilder = new StringBuilder();

    void Awake() 
    {
        if(Instance == null)    
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
    public void InitHtmlCode()
    {
        Debug.Log("html code 초기화");
        strBuilder.Clear();
        strBuilder.Append("<html>");
    }

    public void AddCode(string openTag, string closeTag, string data)
    {
        Debug.Log("AddCode");
        Debug.Log("openTag: " + openTag);
        Debug.Log("closeTag: " + closeTag);
        Debug.Log("data: " + data);

        strBuilder.Append(openTag);
        strBuilder.Append(data);
        strBuilder.Append(closeTag);

        Debug.Log("Added code: " + strBuilder.ToString());
    } 

    public void ShowCode()
    {
        Debug.Log("strBuilder: " + strBuilder.ToString());
    }

    public void MakeHtmlFile()
        {
            Debug.Log("called MakeHtmlFile");
            string path = Application.dataPath + "/index.html";
            
            StreamWriter sw;
            FileStream fs;

            if(!File.Exists(path))
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(strBuilder.ToString());
                sw.Flush();
                sw.Close();
                fs.Close();
                Debug.Log("made HtmlFile");

            }
            else if(File.Exists(path))
            {
                Debug.Log("Already exists, rerun");
                File.Delete(path);
                MakeHtmlFile();
            }
        }
}

