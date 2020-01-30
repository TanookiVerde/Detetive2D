using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsightScreen : FilesMenuScreen
{
    public string screenName;

    [Header("UI")]
    public ObjectLister objectLister;
    public ObjectPicker firstSpace;
    public ObjectPicker secondSpace;

    [SerializeField] private WitnessData marthaData;
    
    public override void OnShow()
    {
        FindObjectOfType<FilesMenu>().SetName(": " + screenName);

        firstSpace.ResetPicker();
        secondSpace.ResetPicker();

        firstSpace.GetComponent<Selectable>().Select();
        base.OnShow();
    }
    public override void OnHide()
    {
        base.OnHide();
    }
    public void Relate()
    {
        CaseData openedCase = InvestigationManager.GetCase();

        var clue1 = (ClueData) firstSpace.GetSelectedObject();
        var clue2 = (ClueData) secondSpace.GetSelectedObject();
        foreach (InsightData i in openedCase.insights)
        {
            if((i.firstClue == clue1 && i.secondClue == clue2) 
                || (i.firstClue == clue2 && i.secondClue == clue1))
            {
                int insightIndex = openedCase.GetInsightIndexFromData(i);
                Files files = Files.Load();
                bool added = files.GetCaseStatus().AddInsight(insightIndex);
                files.Save();
                DialogUI.StartDialog(i.findingDialog, added, DialogType.INSIGHT);
                return;
            }
        }
        DialogUI.StartDialog(marthaData.genericNegativeAnswers[Random.Range(0, marthaData.genericNegativeAnswers.Count)]);
    }
}
