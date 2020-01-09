using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Testimony")]
public class TestimonyData : ScriptableObject
{
    public WitnessData witness;
    public ClueData clue;
    public string description;

    public DialogData findingDialog;
}
