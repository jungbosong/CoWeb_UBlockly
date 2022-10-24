using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Tag;

namespace Tag
{
    [System.Serializable] 
    public class TagInfo
    {
        public string tagType;
        public string tagName;
        public string data;
        public string property;
    }
    [System.Serializable] 
    public class TagData
    {
        public List<TagInfo> tagInfoList = new List<TagInfo>();
    }
}

public class JsonMaker : MonoBehaviour
{
    public static JsonMaker Instance = null;
    List<TagInfo> tagInfoList = new List<TagInfo>();

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
    public void InitJsonData()
    {
        Debug.Log("JsonData초기화");
        tagInfoList.Clear();
    }

    public void AddData(string type, string name, string data, string poperty)
    {
        TagInfo tagInfo = new TagInfo();
        tagInfo.tagType = type;
        tagInfo.tagName = name;
        tagInfo.data = data;
        tagInfo.property = poperty;
        tagInfoList.Add(tagInfo);        
    }

    public void MakeJsonFile()
    {
        Debug.Log("tagInfoList Cnt: " + tagInfoList.Count);

        // json 코드 생성
        TagData tagData = new TagData();
        tagData.tagInfoList = new List<TagInfo>();
        tagData.tagInfoList = tagInfoList;
        string json = JsonUtility.ToJson(tagData);
        
        // 파일로 저장
        string path = Application.dataPath + "/index.json";
            
        StreamWriter sw;
        FileStream fs;

        if(!File.Exists(path))
        {
            fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(json);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        else if(File.Exists(path))
        {
            File.Delete(path);
            MakeJsonFile();
        }
    }
}
