using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.XR;

public class NetworkPlayerPosition : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView; 

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            head.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);
            
            mapPosition(head, XRNode.Head);
            mapPosition(leftHand, XRNode.LeftHand);
            mapPosition(rightHand, XRNode.RightHand); 
        }    
    }

    void mapPosition(Transform target, XRNode node)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
        target.position = position;
        target.rotation = rotation;
    }
}
