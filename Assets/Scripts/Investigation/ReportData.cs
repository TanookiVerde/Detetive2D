using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/Report")]
public class ReportData : ScriptableObject
{
    public List<Question> questions;
    public int maxFailures;
}
[System.Serializable]
public class Question
{
    public string question;
    public List<ScriptableObject> possibleAnswers;
}
