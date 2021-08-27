using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class LetterMode : MonoBehaviour
{
    public bool readLetters = true;
    public Button letterButton;
    public Text buttonText;

    //Sets the original button colour
    void Start()
    {
        letterButton.GetComponent<Image>().color = Color.green;
        buttonText.color = Color.black;
    }

    //Updates the button colour
    public void changeMode()
    {
        if (readLetters == true)
        {
            readLetters = false;
            letterButton.GetComponent<Image>().color = Color.red;
            buttonText.text = "Enable Fingerspelling";
        }
        else
        {
            readLetters = true;
            letterButton.GetComponent<Image>().color = Color.green;
            buttonText.text = "Disable Fingerspelling";
        }
    }
}