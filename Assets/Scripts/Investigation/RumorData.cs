using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Rumor")]
public class RumorData : ScriptableObject
{
    public WitnessData from;
    public WitnessData target;
    public string description;

    public DialogData findingDialog;
}
