using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class HtmlCodeMaker : MonoBehaviour
{
    public static HtmlCodeMaker Instance = null;
    private string code = "";
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
        strBuilder.Append("<html>");
    }

    public void AddHtmlCode()
    {
        strBuilder.Append("</html>");
    }

    public void AddCode(string typeName, string openTag, string closeTag, string data)
    {
        Debug.Log("AddCode");
        Debug.Log("typeName: " + typeName);
        //Debug.Log("tagName: " + tagName);
        Debug.Log("openTag: " + openTag);
        Debug.Log("closeTag: " + closeTag);
        Debug.Log("data: " + data);

        if(typeName == "CTAG")
        {
            Debug.Log("Type's CTAG");
            strBuilder.Append(openTag);
            strBuilder.Append(data);
            strBuilder.Append(closeTag);
            Debug.Log("CTag sb: " + strBuilder.ToString());

        }
        else if(typeName == "TAG")
        {
            Debug.Log("Type's TAG");
            strBuilder.Append(openTag);
            Debug.Log("Tag sb: " + strBuilder.ToString());
        }
        else if(typeName == "NTAG")
        {
            Debug.Log("Type's NTAG");
            strBuilder.Append(data);
            Debug.Log("NTag sb: " + strBuilder.ToString());
        }
        Debug.Log("Added code: " + strBuilder.ToString());
    } 

    public void ShowCode()
    {
        Debug.Log("strBuilder: " + strBuilder.ToString());
    }

    public void MakeHtmlFile()
        {
            Debug.Log("called MakeHtmlFile");
            string path = Application.dataPath + "/indextest.html";
            
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

