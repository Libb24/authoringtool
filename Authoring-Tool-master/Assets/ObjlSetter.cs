using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text;

public class ObjlSetter : MonoBehaviour
{
    public Button FirstButton, SecondButton, ThirdButton, FourthButton, FifthButton, SixthButton;
    public GameObject obj,menu,tbox;
    public Slider MainSlider;
    //public TextMeshPro tbox;
    public int type;
    public string ObjName;
    bool flag = false;
    float SliderVal;
    int STime,ETime,VStime,VEtime;
    // Start is called before the first frame update
    void Start()
    {
        //Event handlers. Basically getters and setters
        FirstButton.onClick.AddListener(() => SetStartTime());
        SecondButton.onClick.AddListener(() => SetEndTime());
        ThirdButton.onClick.AddListener(() => SetVStartTime());
        FourthButton.onClick.AddListener(() => SetVEndTime());
        FifthButton.onClick.AddListener(() => RemoveObj());
        SixthButton.onClick.AddListener(() => Save());
    }

    void MenuAction(int n)
    {

    }

    void SetStartTime()
    {
        STime = (int)SliderVal;
    }

    void SetEndTime()
    {
        ETime = (int)SliderVal;
    }

    void SetVStartTime()
    {
        VStime = (int)SliderVal;
    }

    void SetVEndTime()
    {
        VEtime = (int)SliderVal;
    }

    void RemoveObj()
    {
        Destroy(obj);
        Destroy(menu);
    }

    void Save()
    {
        //Saves the gameobject and its properties to the script 
        //DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
        string path = Application.persistentDataPath;
        //string defaultFilename = string.Format("OSD_log_{0}.txt", DateTime.Now.ToString("yyyyMMMdd"));
        string filename = "SeqScript.txt";
        string fullpath = string.Format("{0}/{1}", path, filename);
        Debug.Log(fullpath);
        Debug.Log(type);
        FileStream fs = null;
        try
        {
            //fs = new FileStream(fullpath, FileMode.CreateNew);
            using (StreamWriter writer = new StreamWriter(fullpath,true))
            {                
                string ScriptLine = string.Format("{0},{1},{2},{3},{4},{5}",type.ToString(),ObjName,STime.ToString(),ETime.ToString(),VStime.ToString(),VEtime.ToString());
                writer.WriteLine(ScriptLine);
            }

        }
        catch (System.Exception)
        {
            Debug.Log("Error");
        }
        finally
        {
            if (fs != null)
            {
                Debug.Log("Done File!");
                fs.Dispose();
            }
        }

        Destroy(obj);
        Destroy(menu);
    }

    // Update is called once per frame
    void Update()
    {
        //Updates Slider Value
        SliderVal = MainSlider.value;
        tbox.GetComponent<TMPro.TextMeshProUGUI>().text = ObjName + "\n " + "Current Slider Value (seconds): " + SliderVal.ToString() + "\n " 
            + "Current Start, End Time: " + STime.ToString() + "," + ETime.ToString() + "\n "
            + "Current Video Start, End Time: " + VStime.ToString() + "," + VEtime.ToString();
    }
}
