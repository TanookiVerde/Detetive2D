using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Insight")]
public class InsightData : ScriptableObject
{
    public ClueData firstClue;
    public ClueData secondClue;
    public string description;

    public DialogData findingDialog;
}
