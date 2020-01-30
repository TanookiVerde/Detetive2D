using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenReportCreator : ReportCreatorScreen
{
    [SerializeField] private Selectable firstSelected;
    public override void OnOpen()
    {
        firstSelected.Select();
        base.OnOpen();
    }
    public override void OnClose()
    {
        base.OnClose();
    }
    public void Begin()
    {
        FindObjectOfType<ReportCreator>().Open();
        FindObjectOfType<ReportCreator>().StartReport();
    }
}
