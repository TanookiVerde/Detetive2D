using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Dialog")]
public class DialogData : ScriptableObject
{
    public List<Speak> dialog;
}
[System.Serializable]
public class Speak
{
    public string what;
    public WitnessData who;
    public Speak(string what, WitnessData who)
    {
        this.what = what;
        this.who = who;
    }
}
