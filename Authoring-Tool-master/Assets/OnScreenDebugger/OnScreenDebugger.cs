using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    // TextMeshPro
using System.IO;
using System;
using System.Text;


/// <summary>
/// OnScreenDebugger Class
/// </summary>
public class OnScreenDebugger : MonoBehaviour
{
    // Children objects of OnScreenDebugger
    public TextMeshPro debugText;
    public GameObject backboard;

    private string dataPath;
    private string persistentDataPath;
    private string temporaryCachePath;
    private string streamingAssetsPath;

    void Start()
    {

        this.dataPath = Application.dataPath;
        this.persistentDataPath = Application.persistentDataPath;
        this.temporaryCachePath = Application.temporaryCachePath;
        this.streamingAssetsPath = Application.streamingAssetsPath;
        Debug.Log(persistentDataPath);
        //Application.OpenURL("http://unity3d.com/");

        // clear debugText in initiation
        this.Log("", true);

        
        //ListFiles(Application.dataPath);
        //this.Log("> Application.dataPath");
        //ListFiles(Application.persistentDataPath);
        //this.Log("> Application.persistentDataPath");
        ListFiles(Application.streamingAssetsPath);
        this.Log("> Application.streamingAssetsPath");

        //SaveLog(Application.dataPath);
        //SaveLog(Application.persistentDataPath);
        SaveLog(Application.streamingAssetsPath, string.Format("OSD_log_{0}.txt", DateTime.Now.ToString("yyyyMMMdd'_'HHmmss")));
    }

    /// <summary>
    /// Queue string message into the TextMeshPro
    /// params:
    ///     newMessage: string message to display
    ///     clearCache: clear cached messages and board if true
    /// </summary>
    void Log(string newMessage, bool clearCache = false)
    {
        string displayCache = clearCache ? "" : ("\n" + debugText.text);
        debugText.text = newMessage + displayCache;
    }

    void ListFiles(string filePath)
    {
        try
        {
            DirectoryInfo dir = new DirectoryInfo(filePath);
            FileInfo[] info = dir.GetFiles("*.*");
            foreach (FileInfo f in info)
            {
                this.Log(f.Name);
            }
        }
        catch (System.Exception e)
        {
            this.Log(e.Message);
        }
        
        this.Log(filePath);
    }

    void SaveLog(string filepath, string _filename = null)
    {
        string path = filepath;
        string defaultFilename = string.Format("OSD_log_{0}.txt", DateTime.Now.ToString("yyyyMMMdd"));
        string filename = _filename is null ?  defaultFilename : _filename.ToString();
        string fullpath = string.Format("{0}/{1}", path, filename);
        FileStream fs = null;
        try
        {
            fs = new FileStream(fullpath, FileMode.CreateNew);
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                writer.WriteLine(this.debugText.text);
                
            }       
            
        }      
        catch (System.Exception)
        {
            this.Log("Save Failed to " + path);
        }
        finally
        {
            if (fs != null)
            {
                this.Log("Save to " + fullpath + " Success!");
                fs.Dispose();
            }               
        }
    }
}
