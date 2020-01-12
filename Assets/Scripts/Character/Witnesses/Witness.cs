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
                bool added = files.AddTestimony(openedCase.GetTestimonyFromData(testimony));
                files.Save();
                DialogUI.StartDialog(testimony.findingDialog, added, DialogType.TESTIMONY);
                return;
            }
        }
        List<string> speech = new List<string>();
        speech.Add(data.genericNegativeAnswers[Random.Range(0, data.genericNegativeAnswers.Count)]);
        DialogUI.StartDialog(speech);
    }
    public void Ask(WitnessData witness)
    {
        CaseData openedCase = InvestigationManager.GetCase();

        foreach (var rumor in data.rumors)
        {
            if (rumor.target == witness)
            {
                Files files = Files.Load();
                bool added = files.AddRumor(openedCase.GetRumorFromData(rumor));
                files.Save();
                DialogUI.StartDialog(rumor.findingDialog, added, DialogType.RUMOR);
                return;
            }
        }
        List<string> speech = new List<string>();
        speech.Add(data.genericNegativeAnswers[Random.Range(0, data.genericNegativeAnswers.Count)]);
        DialogUI.StartDialog(speech);
    }
    public void Introduce()
    {
        CaseData openedCase = InvestigationManager.GetCase();

        Files files = Files.Load();
        bool added = files.AddWitness(openedCase.GetWitnessIndexFromData(data));
        files.Save();
        DialogUI.StartDialog(data.introducingDialog, added, DialogType.WITNESS);
    }
}
