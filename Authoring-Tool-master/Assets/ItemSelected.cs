using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelected : MonoBehaviour
{
    // Start is called before the first frame update
    public Button item;
    public int type;
    public GameObject vidPrefab;
    public GameObject prefab360;
    public GameObject imgPrefab;
    public GameObject menuPrefab;
    GameObject obj1, obj2;
    public string ObjName;
    void Start()
    {
        //Event handler
        item.onClick.AddListener(() => InitStart());
    }
    void InitStart()
    {
        //Debug.Log("Click! "+ObjName+" " + type.ToString());
        //Debug.Log(ObjName);
        //Debug.Log(type);

        //Gets the file type and creates the gameobject and loads the property manager
        
        if (type == 1)
        {
            obj1 = Instantiate(vidPrefab);
            vidScript ps = obj1.GetComponent<vidScript>();
            ps.valSetter(ObjName, 0, 0, 0, 100);
            obj1.SetActive(true);
            ps.Starter();
        }
        else if (type == 2)
        {
            obj1 = Instantiate(imgPrefab);
            imgScript ps = obj1.GetComponent<imgScript>();
            ps.valSetter(ObjName, 0, 0);
            obj1.SetActive(true);
        }
        else if (type == 3)
        {
            obj1 = Instantiate(prefab360);
            FlipScript ps = obj1.GetComponent<FlipScript>();
            ps.valSetter(ObjName, 0, 0, 0, 100);
            obj1.SetActive(true);
            ps.Starter();
        }
        else
        {
            Debug.Log("Error!");
        }
                       
        obj2 = Instantiate(menuPrefab);
        ObjlSetter oscript = obj2.GetComponentInChildren<ObjlSetter>();
        oscript.obj = obj1;
        oscript.ObjName = ObjName;
        oscript.type = type;
        //Debug.Log(type + "HERE!!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
