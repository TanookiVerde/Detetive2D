using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witness : MonoBehaviour
{
    [SerializeField] private Storage storage;
    [SerializeField] private WitnessData data;

    public void Ask(ClueData clue)
    {
        foreach(var testimony in data.testimonys)
        {
            if(testimony.clue == clue)
            {
                Files files = Files.Load();
                bool added = files.AddTestimony(storage.GetTestimonyFromData(testimony));
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
        foreach (var rumor in data.rumors)
        {
            if (rumor.target == witness)
            {
                Files files = Files.Load();
                bool added = files.AddRumor(storage.GetRumorFromData(rumor));
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
        Files files = Files.Load();
        bool added = files.AddWitness(storage.GetWitnessIndexFromData(data));
        files.Save();
        DialogUI.StartDialog(data.introducingDialog, added, DialogType.WITNESS);
    }
}
