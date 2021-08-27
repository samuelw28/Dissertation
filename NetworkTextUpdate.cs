using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkTextUpdate : MonoBehaviour, IPunObservable
{
    public Text signText;

    void Start()
    {
        PhotonView pv = GetComponent<PhotonView>();
        if (pv)
        {
            pv.ObservedComponents.Add(this);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {        
            Debug.Log("Lets goooooo");
            stream.SendNext(signText);
        }
        else
        {
            Debug.Log("Lets not goooooo");
            this.signText = (Text)stream.ReceiveNext();
            signText.text = this.signText.text;
        }
    }
}
