using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class loaderScript : MonoBehaviour
{
    private List<GameObject> objList;
    private long elapsed = 0;
    public GameObject vidPrefab;
    public GameObject prefab360;
    public GameObject imgPrefab;
    private void Start()
    {
        LoadObjects("seqScript");
        StartCoroutine(Timer());
        //sceneController();
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SceneController();
            elapsed++;
        }
    }

    private int LoadObjects(string scriptSource)
    {
        objList = new List<GameObject>();

        //string str = Resources.Load<TextAsset>(scriptSource).text;

        //StringReader strReader = new StringReader(str);
        string path = Application.persistentDataPath;        
        string filename = "SeqScript.txt";
        string InpStr = string.Format("{0}/{1}", path, filename);
        StreamReader strReader = new StreamReader(InpStr);
        //strReader.ReadLine();
        string curStr = strReader.ReadLine();
        Debug.Log(curStr);
        while (curStr!=null)
        {
            /* Type Codes
            * 1: Video
            * 2: Image
            * 3: 360 Video
            * 4: Quiz
            */
            string[] curList = curStr.Split(',');
            //Debug.Log(curList[0] == "1");
            if (curList[0] == "1")
            {
                GameObject obj = Instantiate(vidPrefab);                
                //Debug.Log(typeof(obj));
                //obj.SetActive(false);
                objList.Add(obj);
                vidScript ps = obj.GetComponent<vidScript>();
                ps.valSetter(curList[1],long.Parse(curList[2]),long.Parse(curList[3]), long.Parse(curList[4]), long.Parse(curList[5]));
                //Debug.Log(ps.vidSrc);
                obj.SetActive(false);
            }
            else if (curList[0] == "2")
            {
                GameObject obj = Instantiate(imgPrefab);                
                objList.Add(obj);
                imgScript ps = obj.GetComponent<imgScript>();
                ps.valSetter(curList[1], long.Parse(curList[2]), long.Parse(curList[3]));
                obj.SetActive(false);

            }
            else if (curList[0] == "3")
            {
                GameObject obj = Instantiate(prefab360);                
                objList.Add(obj);                
                FlipScript ps = obj.GetComponent<FlipScript>();
                ps.valSetter(curList[1], long.Parse(curList[2]), long.Parse(curList[3]), long.Parse(curList[4]), long.Parse(curList[5]));
                obj.SetActive(false);
            }
            else if (curList[0] == "4")
            {

            }
            else
            {
                Debug.Log(curStr);
                Debug.Log("Invalid Type in loader");
                //return 1;
            }

            curStr = strReader.ReadLine();
        }
        strReader.Close();
        return 0;
    }
    

    private void SceneController()
    {
        List<GameObject> copyList = new List<GameObject>();
        foreach(GameObject obj in objList)
        {
            copyList.Add(obj);
        }

        foreach(GameObject obj in copyList)
        {
            //vidScript ps = obj.GetComponent<vidScript>();
            //ps.starter();
            //obj.SetActive(true);

            if (obj.GetComponent<vidScript>() != null)
            {
                vidScript ps = obj.GetComponent<vidScript>();
                if (ps.initTime == elapsed)
                {
                    obj.SetActive(true);
                    ps.Starter();
                }
                else if (ps.destroyTime == elapsed)
                {
                    Destroy(obj);
                    objList.Remove(obj);
                }
            }
            else if (obj.GetComponent<imgScript>() != null)
            {
                imgScript ps = obj.GetComponent<imgScript>();
                if (ps.initTime == elapsed)
                {
                    obj.SetActive(true);                    
                }
                else if (ps.destroyTime == elapsed)
                {
                    Destroy(obj);
                    objList.Remove(obj);
                }
            }
            else if (obj.GetComponent<FlipScript>() != null)
            {
                FlipScript ps = obj.GetComponent<FlipScript>();
                if (ps.initTime == elapsed)
                {
                    obj.SetActive(true);
                    ps.Starter();
                }
                else if (ps.destroyTime == elapsed)
                {
                    Destroy(obj);
                    objList.Remove(obj);
                }
            }

            
        }        
    }
    
    void Update()
    {
        //int count = 0;
        //elapsed += Time.deltaTime;
        //if (elapsed >= 1f)
        //{
        //    elapsed = elapsed % 1f;
        //    if (count == 0) { sceneController(); }
        //    else { return; }
        //}
    }
}