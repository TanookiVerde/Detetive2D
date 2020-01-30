using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/Clue")]
public class ClueData : ScriptableObject
{
    public Sprite img;
    public string clueName;
    public string clueDescription;
    public bool important;

    public DialogData findingDialog;
}
