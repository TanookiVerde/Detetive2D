using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/Witness")]
public class WitnessData : ScriptableObject
{
    public string witnessName;
    public Sprite image;
    public int age;
    public string job;

    public DialogData introducingDialog;

    public List<RumorData> rumors;
    public List<TestimonyData> testimonys;

    public List<string> genericNegativeAnswers;
}

