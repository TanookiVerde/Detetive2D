using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaseInfoScreen : FilesMenuScreen
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text data;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Button firstSelected;

    public string screenName;
    public override void OnShow()
    {
        CaseData openedCase = InvestigationManager.GetCase();

        FindObjectOfType<FilesMenu>().SetName(": " + screenName);
        image.sprite = openedCase.image;
        data.text = "Localização: " + openedCase.location; 
        description.text = openedCase.description;
        base.OnShow();
        firstSelected.Select();
    }
    public override void OnHide()
    {
        base.OnHide();
    }
    public void EndCase()
    {
        FindObjectOfType<ReportCreator>().Open();
    }
}
