using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSpot : MonoBehaviour
{
    public DialogData data;
    public bool oneTimeOnly;
    public bool autoStart;

    public bool played;

    public void Play()
    {
        played = true;
    }
}
