using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class ChangeMode : MonoBehaviour
{
    public bool readSigns;
    public bool readLetters;
    public Button readButton;
    public Button letterButton;
    public Text readButtonText;
    public Text letterButtonText;
    public Text clearButtonText;
    public Color enableCol;
    public Color disableCol;
    public Color textCol;


    //Sets the original button colour
    void Start()
    {
        enableCol = Color.green;
        disableCol = Color.red;
        textCol = Color.black;
        readButton.GetComponent<Image>().color = enableCol;
        letterButton.GetComponent<Image>().color = disableCol;
        readButtonText.color = textCol;
        letterButtonText.color = textCol;
        readSigns = true;
        readLetters = false;
    }

    //Updates the button colour
    public void changeRead()
    {
        if (readSigns == true)
        {
            readSigns = false;
            readButton.GetComponent<Image>().color = disableCol;
            readButtonText.text = "Sign Reading: Disabled";
        }
        else
        {
            readSigns = true;
            readButton.GetComponent<Image>().color = enableCol;
            readButtonText.text = "Sign Reading: Enabled";
        }
    }

    public void changeLetter()
    {
        if (readLetters == true)
        {
            readLetters = false;
            letterButton.GetComponent<Image>().color = disableCol;
            letterButtonText.text = "Fingerspelling: Disabled";
            clearButtonText.text = "Clear Screen";
        }
        else
        {
            readLetters = true;
            letterButton.GetComponent<Image>().color = enableCol;
            letterButtonText.text = "Fingerspelling: Enabled";
            clearButtonText.text = "Delete Letter";
        }
    }
}
