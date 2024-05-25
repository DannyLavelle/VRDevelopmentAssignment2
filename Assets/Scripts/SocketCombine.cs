using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketCombine : MonoBehaviour
{

    public string debugMessage = "Default Debug Message";
    [HideInInspector]
    public bool hammerCombined = false;

    public void DebugMessage()
    {
        Debug.Log(debugMessage);
    }

    public void HammerCombine()
    {
        hammerCombined = true;
    }
}
