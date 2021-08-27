using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class ColourMode : MonoBehaviour
{
    public bool readSigns = true;
    public Button readButton;
    public Button changeButtonOne;
    public Button changeButtonTwo;
    public Text buttonText;
    public bool colourBlindMode = false;
    public Color enableCol;
    public Color disableCol;


    //Sets the original button colour
    void Start()
    {
        enableCol = Color.green;
        disableCol = Color.red;
        readButton.GetComponent<Image>().color = enableCol;
        buttonText.color = Color.black;
    }

    //Updates the button colour
    public void changeMode()
    {
        if (readSigns == true)
        {
            readSigns = false;
            readButton.GetComponent<Image>().color = disableCol;
            buttonText.text = "Enable Sign Reading";
        }
        else
        {
            readSigns = true;
            readButton.GetComponent<Image>().color = enableCol;
            buttonText.text = "Disable Sign Reading";
        }
    }

    public void changeColourblind()
    {
        if (colourBlindMode == false)
        {
            colourBlindMode = true;
            enableCol = Color.yellow;
            disableCol = Color.blue;
            readButton.GetComponent<Image>().color = enableCol;
            changeButtonOne.GetComponent<Image>().color = enableCol;
            changeButtonTwo.GetComponent<Image>().color = enableCol;
            buttonText.text = "Disable Colourblind Mode";
        }
        else
        {
            colourBlindMode = false;
            enableCol = Color.green;
            disableCol = Color.red;
            readButton.GetComponent<Image>().color = disableCol;
            changeButtonOne.GetComponent<Image>().color = disableCol;
            changeButtonTwo.GetComponent<Image>().color = disableCol;
            buttonText.text = "Enable Colourblind Mode";
        } 
    }
}
