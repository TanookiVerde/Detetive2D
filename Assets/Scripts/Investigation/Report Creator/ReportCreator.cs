using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class ReportCreator : MenuBehaviour
{
    public CanvasGroup filesMenuCanvasGroup;
    public CanvasGroup reportCreatorCanvasGroup;
    public List<ReportCreatorScreen> screens;

    private Coroutine loop;

    public override void OnOpen()
    {
        base.OnOpen();
        foreach (var screen in screens)
        {
            screen.Close();
        }
        screens[0].Open();
        StartCoroutine(Loop());
    }
    public override void OnClose()
    {
        base.OnClose();
        if (loop != null)
            StopCoroutine(Loop());
    }
    public void StartReport()
    {
        screens[0].Close();
        screens[1].Open();
        screens[1].GetComponent<QuestionScreenReportCreator>().receiveReport += ReceiveReport;
    }
    public ReportData GetReportData()
    {
        return InvestigationManager.GetCase().report;
    }
    private IEnumerator Loop()
    {
        yield return null;
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Escape))
                Close();
        }
    }
    public void ReceiveReport(List<ScriptableObject> list)
    {
        screens[1].GetComponent<QuestionScreenReportCreator>().receiveReport -= ReceiveReport;
        bool success = AnalyseReport(list);
        FindObjectOfType<ReportReaction>().Begin(success);
        Close();
    }
    public bool AnalyseReport(List<ScriptableObject> list)
    {
        List<Question> qa = InvestigationManager.GetCase().report.questions;
        int correctAnswers = 0;
        for(int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < qa[i].possibleAnswers.Count; j++)
            {
                if (list[i] == qa[i].possibleAnswers[j])
                {
                    correctAnswers++;
                    break;
                }
            }
        }
        float r = (float) correctAnswers / list.Count;
        print("REPORT GRADE: " + r);
        return r >= 0.75f;
    }
}
