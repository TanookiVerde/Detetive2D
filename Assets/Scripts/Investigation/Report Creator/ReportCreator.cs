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

    public List<ScriptableObject> answers;

    public override void OnOpen()
    {
        base.OnOpen();
        foreach (var screen in screens)
        {
            screen.Close();
        }
        screens[0].Open();
    }
    public void StartReport()
    {
        screens[0].Close();
        screens[1].Open();
    }
    public ReportData GetReportData()
    {
        return InvestigationManager.GetCase().report;
    }
}
