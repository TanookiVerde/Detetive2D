using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    public ClueData clueData;

    public void Investigate()
    {
        CaseData openedCase = InvestigationManager.GetCase();

        Files files = Files.Load();
        bool added = files.GetCaseStatus().AddClue(openedCase.clues.IndexOf(clueData));
        files.Save();
        DialogUI.StartDialog(clueData.findingDialog, added, DialogType.CLUE);
    }
    public int GetCase()
    {
        Storage s = InvestigationManager.me.storage;
        for(int i = 0; i < s.cases.Count; i++)
        {
            for(int j = 0; j < s.cases[i].clues.Count; j++)
            {
                if (s.cases[i].clues[j] == clueData)
                    return i;
            }
        }
        return -1;
    }
}
