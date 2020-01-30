using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witness : MonoBehaviour
{
    [SerializeField] private WitnessData data;

    public void Ask(ClueData clue)
    {
        CaseData openedCase = InvestigationManager.GetCase();

        foreach (var testimony in data.testimonys)
        {
            if(testimony.clue == clue)
            {
                Files files = Files.Load();
                bool added = files.GetCaseStatus().AddTestimony(openedCase.GetTestimonyFromData(testimony));
                files.Save();
                DialogUI.StartDialog(testimony.findingDialog, added, DialogType.TESTIMONY);
                return;
            }
        }
        DialogUI.StartDialog(data.genericNegativeAnswers[Random.Range(0, data.genericNegativeAnswers.Count)]);
    }
    public void Ask(WitnessData witness)
    {
        CaseData openedCase = InvestigationManager.GetCase();

        foreach (var rumor in data.rumors)
        {
            if (rumor.target == witness)
            {
                Files files = Files.Load();
                bool added = files.GetCaseStatus().AddRumor(openedCase.GetRumorFromData(rumor));
                files.Save();
                DialogUI.StartDialog(rumor.findingDialog, added, DialogType.RUMOR);
                return;
            }
        }
        DialogUI.StartDialog(data.genericNegativeAnswers[Random.Range(0, data.genericNegativeAnswers.Count)]);
    }
    public void Introduce()
    {
        CaseData openedCase = InvestigationManager.GetCase();

        Files files = Files.Load();
        bool added = files.GetCaseStatus().AddWitness(openedCase.GetWitnessIndexFromData(data));
        files.Save();
        DialogUI.StartDialog(data.introducingDialog, added, DialogType.WITNESS);
    }
    public int GetCase()
    {
        Storage s = InvestigationManager.me.storage;
        for (int i = 0; i < s.cases.Count; i++)
        {
            for (int j = 0; j < s.cases[i].witnesses.Count; j++)
            {
                if (s.cases[i].witnesses[j] == data)
                    return i;
            }
        }
        return -1;
    }
}
