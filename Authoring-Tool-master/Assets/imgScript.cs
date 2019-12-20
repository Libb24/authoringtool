using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class imgScript : MonoBehaviour
{
    public GameObject pan;
    Texture texture;
    public string imgName;
    public long initTime;
    public long destroyTime;
    // Start is called before the first frame update
    void Start()
    {


        //string str = Resources.Load<TextAsset>("imgSelector").text;
        texture = Resources.Load("Images_1/"+imgName) as Texture;
        if (texture)
        {
            Debug.Log("OK!");
        }
        else
        {
            Debug.Log("NO! :(");
        }
        //pan = GameObject.Find("imgPan");
        pan.GetComponent<Renderer>().material.mainTexture = texture;
        //StartCoroutine(waitFor());
        //WaitForSecondsRealtime(5);

    }
    //IEnumerator waitFor()
    //{


    //    string str = Resources.Load<TextAsset>("imgSelector").text;
    //    texture = Resources.Load(str) as Texture;
    //    if (texture)
    //    {
    //        Debug.Log("OK!");
    //    }
    //    else
    //    {
    //        Debug.Log("NO! :(");
    //    }
    //    pan = GameObject.Find("imgPan");
    //    pan.GetComponent<Renderer>().material.mainTexture = texture;
    //    yield return null;
    //}
    // Update is called once per frame
    void Update()
    {

    }

    public void valSetter(string src = null, long sTime = 0, long eTime = 0)
    {
        imgName = src;
        initTime = sTime;
        destroyTime = eTime;
    }
}

