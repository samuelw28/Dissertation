using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class ReadMode : MonoBehaviour
{
    public bool readSigns = true;
    public Button readButton;
    public Text buttonText;

    //Sets the original button colour
    void Start()
    {
        readButton.GetComponent<Image>().color = Color.green;
        buttonText.color = Color.black;
    }

    //Updates the button colour
    public void changeMode()
    {
        if (readSigns == true)
        {
            readSigns = false;
            readButton.GetComponent<Image>().color = Color.green;
            buttonText.text = "Enable Sign Reading";
        }
        else
        {
            readSigns = true;
            readButton.GetComponent<Image>().color = Color.green;
            buttonText.text = "Disable Sign Reading";
        }
    }
}
