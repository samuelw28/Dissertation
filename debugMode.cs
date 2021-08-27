using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

[Serializable]
public class debugMode : MonoBehaviour
{
    public bool readSigns = true;
    public Button debugButton;

    public void changeMode()
    {
        if (readSigns == true)
        {
            readSigns = false;
            debugButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            readSigns = true;
            debugButton.GetComponent<Image>().color = Color.green;
        }
    }
}
