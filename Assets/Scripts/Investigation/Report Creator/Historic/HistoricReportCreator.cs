using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoricReportCreator : MonoBehaviour
{
    public ReportData data;
    public Transform root;
    public GameObject qAPrefab;

    public List<ScriptableObject> answers;
    public List<Transform> answersUI = new List<Transform>();

    public void Initialize()
    {
        for(int i = answersUI.Count-1; i >= 0; i--)
        {
            Destroy(answersUI[i].gameObject);
        }
        data = InvestigationManager.GetCase().report;
        answers = new List<ScriptableObject>();
        answersUI = new List<Transform>();
    }
    public void AddAnswer(int questionIndex, ScriptableObject answer, DataType type)
    {
        print(answersUI.Count + "/" + questionIndex);
        var go = Instantiate(qAPrefab, root).GetComponent<HistoricAnswer>();
        var question = data.questions[questionIndex];
        switch (type)
        {
            case DataType.CLUE:
                go.SetInfo(question.question, ((ClueData)answer));
                break;
            case DataType.WITNESS:
                go.SetInfo(question.question, ((WitnessData)answer));
                break;
            case DataType.TESTIMONY:
                go.SetInfo(question.question, ((TestimonyData)answer));
                break;
            case DataType.RUMOR:
                go.SetInfo(question.question, ((RumorData)answer));
                break;
            case DataType.INSIGHT:
                go.SetInfo(question.question, ((InsightData)answer));
                break;
        }
        if (questionIndex < answersUI.Count)
        {
            Destroy(answersUI[questionIndex].gameObject);
            answersUI[questionIndex] = go.transform;
            go.transform.SetSiblingIndex(questionIndex);
            answers[questionIndex] = answer;
        }
        else
        {
            answersUI.Add(go.transform);
            answers.Add(answer);
        }
    }
    public void RemoveAnswer()
    {
        var temp = answersUI[answersUI.Count - 1];
        answersUI.Remove(temp);
        Destroy(temp.gameObject);
        //answers.Remove() the last
    }
}
public enum DataType
{
    CLUE, WITNESS, TESTIMONY, RUMOR, INSIGHT
}
