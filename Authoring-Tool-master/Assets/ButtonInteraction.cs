using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    //Make sure to attach these Buttons in the Inspector
    public Button FirstButton, SecondButton, ThirdButton, FourthButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        SecondButton.onClick.AddListener(() => PopulateMenu(2));
        //m_YourSecondButton.onClick.AddListener(() => ButtonClicked(2));
        //m_YourThirdButton.onClick.AddListener(() => ButtonClicked(3));
        //m_YourThirdButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }

    public void PopulateMenu(int n)
    {
        if (n == 1)
        {

        }
        else if (n == 2)
        {

        }
        else if (n == 3)
        {

        }
        else if (n == 4)
        {
            
        }
        else
        {
            return;
        }

    }
}
