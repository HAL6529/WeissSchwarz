using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class MLAPI_GUI : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 100, 50),"StartHost"))
        {
            NetworkManager.Singleton.StartHost();
        }
        if (GUI.Button(new Rect(20, 70, 100, 50), "StartClient"))
        {
            NetworkManager.Singleton.StartClient();
        }
    }
}
