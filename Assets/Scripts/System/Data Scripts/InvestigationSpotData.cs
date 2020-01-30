using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvestigationSpotData : ScriptableObject
{
    public Sprite background;
    [SerializeField] private WitnessData marthaData;

    public virtual void Investigate(Vector2 normalizedPosition) {}
    protected void FoundClue(ClueData clue)
    {
        CaseData openedCase = InvestigationManager.GetCase();
        int clueIndex = openedCase.GetClueIndexFromData(clue);
        if (clueIndex >= 0) {
            Files files = Files.Load();
            bool added = files.GetCaseStatus().AddClue(openedCase.GetClueIndexFromData(clue));
            files.Save();
            Debug.Log("ADDED: "+ added);
            DialogUI.StartDialog(clue.findingDialog, added, DialogType.CLUE);
        }
        else
        {
            NoClueFound();
        }
    }
    protected void FoundCase(CaseData caseData)
    {
        int caseIndex = InvestigationManager.me.storage.cases.IndexOf(caseData);
        InvestigationManager.SetCase(caseIndex);
        Files files = Files.Load();
        files.SetInitialClues(caseData.initialClues, caseIndex);
        files.Save();
        DialogUI.StartDialog(caseData.findingDialog, InvestigationManager.me.currentCase != caseIndex, DialogType.CASE);
    }
    protected void NoClueFound()
    {
        DialogUI.StartDialog(marthaData.genericNegativeAnswers[Random.Range(0, marthaData.genericNegativeAnswers.Count)]);
    }
}
[System.Serializable]
public class ClueSpot
{
    public Vector2 position;
    public ClueData clue;
    public float colliderSize;
}
[System.Serializable]
public class CaseSpot
{
    public Vector2 position;
    public CaseData caseData;
    public float colliderSize;
}
