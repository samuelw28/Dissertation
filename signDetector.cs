using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

[Serializable]
public struct Sign
{
    public string name;
    public List<Vector3> fingerData;
    public UnityEvent onRecognised;
    public bool isLetter;
}

public class signDetector : MonoBehaviour
{
    public float threshold = 0.05f;
    public OVRSkeleton skeleton;
    public List<Sign> signList;
    public bool readSigns;
    public bool readLetters;
    private List<OVRBone> fingerBones;
    private Sign previousSign;
    public Sign currentSign;
    public Text displayText;
    private float runTime = 0.0f;
    public float delay;

    //Start is called before the first frame update
    void Start()
    {
        readSigns = GameObject.Find("readButton").GetComponent<ChangeMode>().readSigns;
        readLetters = GameObject.Find("letterButton").GetComponent<ChangeMode>().readLetters;
        if(readSigns)
        {
            fingerBones = new List<OVRBone>(skeleton.Bones);
            previousSign = new Sign();
        }
    }

    //Update is called once per frame
    void Update()
    {
        if (Time.time > runTime)
        {
            runTime += delay;
            readSigns = GameObject.Find("readButton").GetComponent<ChangeMode>().readSigns;
            readLetters = GameObject.Find("letterButton").GetComponent<ChangeMode>().readLetters;
            if(readSigns)
            {
                fingerBones = new List<OVRBone>(skeleton.Bones);
                
                currentSign = recogniseSign();
                Sign otherSign = currentSign;
                bool hasRecognised = !currentSign.Equals(new Sign());
                if (gameObject.name == "signDetectionLeft")
                {
                    otherSign = GameObject.Find("signDetectionRight").GetComponent<signDetector>().currentSign;
                }
                else if (gameObject.name == "signDetectionRight")
                {
                    otherSign = GameObject.Find("signDetectionLeft").GetComponent<signDetector>().currentSign;
                }

                if (hasRecognised && !currentSign.Equals(previousSign))
                {
                    if (currentSign.isLetter || otherSign.isLetter)
                    {
                        letterCheck(otherSign);
                    }
                    else if (currentSign.name == "restingSign" || currentSign.name == "leftSpellingHand")
                    {
                        displayText.text = displayText.text + "";       
                    }
                    else
                    {
                        if (readLetters == false)
                        {
                            displayText.text = displayText.text + " " + currentSign.name;
                        }
                    }

                    previousSign = currentSign;
                    currentSign.onRecognised.Invoke();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !readSigns)
        {
            addSign();
        }
    }

    //Adds a new sign to the list of regonised signs
    void addSign()
    {
        Sign s = new Sign();
        s.name = "New Sign";
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerBones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }
        s.fingerData = data;
        signList.Add(s);
    }

    //Checks the current sign against the list of recognised signs
    Sign recogniseSign()
    {
        Sign currentSign = new Sign();
        float currentMin = Mathf.Infinity;
        foreach (var sign in signList)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, sign.fingerData[i]);
                if (distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance = sumDistance + distance;
            }

            if ((!isDiscarded) && (sumDistance < currentMin))
            {
                currentMin = sumDistance;
                currentSign = sign;
            }
        }
        return currentSign;
    }

    //Checks what letter is being signed
    void letterCheck(Sign checkSign)
    {
        if (readLetters)
        {
            if ((currentSign.name == "leftA" || currentSign.name == "restingSign") && (checkSign.name == "leftA" || checkSign.name == "restingSign"))
            {
                displayText.text = displayText.text + "A";
            }
            else if ((currentSign.name == "leftB" || currentSign.name == "rightB") && (checkSign.name == "leftB" || checkSign.name == "rightB"))
            {
                displayText.text = displayText.text + "B";
            }
            else if ((currentSign.name == "leftSpellingHand" || currentSign.name == "rightD") && (checkSign.name == "leftSpellingHand" || checkSign.name == "rightD"))
            {
                displayText.text = displayText.text + "C";
            }
            else if ((currentSign.name == "leftD" || currentSign.name == "rightD") && (checkSign.name == "leftD" || checkSign.name == "rightD"))
            {
                displayText.text = displayText.text + "D";
            }
            else if ((currentSign.name == "leftE" || currentSign.name == "restingSign") && (checkSign.name == "leftE" || checkSign.name == "restingSign"))
            {
                displayText.text = displayText.text + "E";
            }
            else if ((currentSign.name == "leftF" || currentSign.name == "rightF") && (checkSign.name == "leftF" || checkSign.name == "rightF"))
            {
                displayText.text = displayText.text + "F";
            }
            else if ((currentSign.name == "leftG" || currentSign.name == "rightG") && (checkSign.name == "leftG" || checkSign.name == "rightG"))
            {
                displayText.text = displayText.text + "G";
            }
            else if ((currentSign.name == "leftSpellingHand" || currentSign.name == "rightH") && (checkSign.name == "leftSpellingHand" || checkSign.name == "rightH"))
            {
                displayText.text = displayText.text + "H";
            }
            else if ((currentSign.name == "leftI" || currentSign.name == "restingSign") && (checkSign.name == "leftI" || checkSign.name == "restingSign"))
            {
                displayText.text = displayText.text + "I";
            }
            else if ((currentSign.name == "leftSpellingHand" || currentSign.name == "rightJ") && (checkSign.name == "leftSpellingHand" || checkSign.name == "rightJ"))
            {
                displayText.text = displayText.text + "J";
            }
            else if ((currentSign.name == "leftD" || currentSign.name == "rightK") && (checkSign.name == "leftD" || checkSign.name == "rightK"))
            {
                displayText.text = displayText.text + "K";
            }
            else if ((currentSign.name == "leftSpellingHand" || currentSign.name == "rightL") && (checkSign.name == "leftSpellingHand" || checkSign.name == "rightL"))
            {
                displayText.text = displayText.text + "L";
            }
            else if ((currentSign.name == "leftSpellingHand" || currentSign.name == "rightM") && (checkSign.name == "leftSpellingHand" || checkSign.name == "rightM"))
            {
                displayText.text = displayText.text + "M";
            }
            else if ((currentSign.name == "leftSpellingHand" || currentSign.name == "rightF") && (checkSign.name == "leftSpellingHand" || checkSign.name == "rightF"))
            {
                displayText.text = displayText.text + "N";
            }
            else if ((currentSign.name == "leftO" || currentSign.name == "restingSign") && (checkSign.name == "leftO" || checkSign.name == "restingSign"))
            {
                displayText.text = displayText.text + "O";
            }
            else if ((currentSign.name == "leftD" || currentSign.name == "rightP") && (checkSign.name == "leftD" || checkSign.name == "rightP"))
            {
                displayText.text = displayText.text + "P";
            }
            else if ((currentSign.name == "leftQ" || currentSign.name == "rightR") && (checkSign.name == "leftQ" || checkSign.name == "rightR"))
            {
                displayText.text = displayText.text + "Q";
            }  
            else if ((currentSign.name == "leftSpellingHand" || currentSign.name == "rightR") && (checkSign.name == "leftSpellingHand" || checkSign.name == "rightR"))
            {
                displayText.text = displayText.text + "R";
            }    
            else if ((currentSign.name == "leftS" || currentSign.name == "rightS") && (checkSign.name == "leftS" || checkSign.name == "rightS"))
            {
                displayText.text = displayText.text + "S";
            }
            else if ((currentSign.name == "leftT" || currentSign.name == "rightL") && (checkSign.name == "leftT" || checkSign.name == "rightL"))
            {
                displayText.text = displayText.text + "T";
            }
            else if ((currentSign.name == "leftU" || currentSign.name == "restingSign") && (checkSign.name == "leftU" || checkSign.name == "restingSign"))
            {
                displayText.text = displayText.text + "U";
            }                  
            else if ((currentSign.name == "leftSpellingHand" || currentSign.name == "rightV") && (checkSign.name == "leftSpellingHand" || checkSign.name == "rightV"))
            {
                displayText.text = displayText.text + "V";
            }
            else if ((currentSign.name == "leftO" || currentSign.name == "Four") && (checkSign.name == "leftO" || checkSign.name == "Four"))
            {
                displayText.text = displayText.text + "W";
            }
            else if ((currentSign.name == "leftX" || currentSign.name == "rightL") && (checkSign.name == "leftX" || checkSign.name == "rightL"))
            {
                displayText.text = displayText.text + "X";
            }
            else if ((currentSign.name == "leftY" || currentSign.name == "rightL") && (checkSign.name == "leftY" || checkSign.name == "rightL"))
            {
                displayText.text = displayText.text + "Y";
            }
            else if ((currentSign.name == "leftSpellingHand" || currentSign.name == "rightZ") && (checkSign.name == "leftSpellingHand" || checkSign.name == "rightZ"))
            {
                displayText.text = displayText.text + "Z";
            }
            else if ((currentSign.name == "leftU" || currentSign.name == "Five") && (checkSign.name == "leftU" || checkSign.name == "Five"))
            {
                displayText.text = displayText.text + " ";
            }            
        }    
    }
}
