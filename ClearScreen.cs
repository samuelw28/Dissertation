using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class ClearScreen : MonoBehaviour
{
    public Text signText;
    public bool readLetters;
    private float runTime = 0.0f;
    public float delay = 0.5f;

    public void clear()
    {
        readLetters = GameObject.Find("letterButton").GetComponent<ChangeMode>().readLetters;
        if (readLetters == false)
        {
            signText.text = "";
        }
        else
        {
            if (Time.time > runTime)
            {
                runTime += delay;
                if (signText.text != "")
                {
                    signText.text = signText.text.Remove(signText.text.Length - 1, 1);
                }
            }
        }
    }
}
