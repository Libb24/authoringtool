using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button SecondButton;
    void Start()
    {
        SecondButton.onClick.AddListener(() => PopulateMenu(2));
    }

    void PopulateMenu(int n)
    {
        Debug.Log("Click!");

    }

    // Update is called once per frame
    void Update()
    {
        //SecondButton.onClick.AddListener(() => PopulateMenu(2));
    }

    
}
