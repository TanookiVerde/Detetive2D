using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HistoricAnswer : MonoBehaviour
{
    [SerializeField] private TMP_Text question;
    [SerializeField] private TMP_Text answer;
    public void SetInfo(string question, ClueData data)
    {
        this.question.text = question;
        this.answer.text = data.name;
    }
    public void SetInfo(string question, WitnessData data)
    {
        this.question.text = question;
        this.answer.text = data.name;
    }
    public void SetInfo(string question, TestimonyData data)
    {
        this.question.text = question;
        this.answer.text = data.name;
    }
    public void SetInfo(string question, RumorData data)
    {
        this.question.text = question;
        this.answer.text = data.name;
    }
    public void SetInfo(string question, InsightData data)
    {
        this.question.text = question;
        this.answer.text = data.name;
    }
}
