using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ObjLoader : MonoBehaviour
{    
    public Button FirstButton, SecondButton, ThirdButton, FourthButton;
    public GameObject SceneLoader, Menu1, Menu2;
    public GameObject ButtonPrefab, parentGameObject;
    private Object[] textures, vids;
    private Sprite mySprite;
    
    void Start()
    {
        //Attach events to buttons
        FirstButton.onClick.AddListener(() => Loader(1));
        SecondButton.onClick.AddListener(() => Loader(2));
        ThirdButton.onClick.AddListener(() => Loader(3));
        FourthButton.onClick.AddListener(() => Loader(4));

        //Script is saved at the persistent datapath
        string rootFolder = Application.persistentDataPath;
        string authorsFile = "SeqScript.txt";
        if (File.Exists(Path.Combine(rootFolder, authorsFile)))
        {
            // If file found, delete it    
            File.Delete(Path.Combine(rootFolder, authorsFile));            
        }

        Loader(1);
    }

    //Loads the object previews in the menu
    public void Loader(int n)
    {
        if (n == 1)
        {
            Clear();
            textures = Resources.LoadAll("Images_1", typeof(Texture2D));
           
            int i = 0;

            foreach (Texture2D t in textures)
            {
                GameObject temp = Instantiate(ButtonPrefab);
                //temp.transform.localScale();
                mySprite = Sprite.Create(t, new Rect(0.0f, 0.0f, t.width, t.height), new Vector2(0.5f, 0.5f), 100.0f);
                temp.transform.SetParent(parentGameObject.transform, false);
                //Instantiate(ButtonPrefab);
                temp.GetComponent<Image>().sprite = mySprite;
                ItemSelected itsel = temp.GetComponent<ItemSelected>();
                itsel.type = 2;
                itsel.ObjName = t.name;
                //Debug.Log(textures[i].name);
                i++;
            }

            //Debug.Log(i);
        }
        else if (n == 2)
        {
            Clear();
            vids = Resources.LoadAll("Videos_1", typeof(VideoClip));
            int i = 0;
            foreach (VideoClip v in vids)
            {
                GameObject temp = Instantiate(ButtonPrefab);
                temp.GetComponentInChildren<Text>().text = v.name;
                ItemSelected itsel = temp.GetComponent<ItemSelected>();
                itsel.type = 1;
                temp.transform.SetParent(parentGameObject.transform, false);
                itsel.ObjName = v.name;
                i++;
            }

        }
        else if (n == 3)
        {
            Clear();
            vids = Resources.LoadAll("360Videos", typeof(VideoClip));
            int i = 0;
            foreach (VideoClip v in vids)
            {
                GameObject temp = Instantiate(ButtonPrefab);
                temp.GetComponentInChildren<Text>().text = v.name;
                temp.transform.SetParent(parentGameObject.transform, false);
                ItemSelected itsel = temp.GetComponent<ItemSelected>();
                itsel.type = 3;
                itsel.ObjName = v.name;
                i++;
            }
        }
        else if (n == 4)
        {
            //Disables the menus and loads the script
            SceneLoader.SetActive(true);
            Menu1.SetActive(false);
            Menu2.SetActive(false);
        }
        else
        {
            Debug.Log("Invalid Button Press");
        }
    }
    //Deletes existing objects
    void Clear()
    {
        foreach (Transform child in parentGameObject.transform)
            Destroy(child.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
