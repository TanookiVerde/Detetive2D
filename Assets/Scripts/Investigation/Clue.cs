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
        bool added = files.AddClue(openedCase.clues.IndexOf(clueData));
        files.Save();
        DialogUI.StartDialog(clueData.findingDialog, added, DialogType.CLUE);
    }
}
