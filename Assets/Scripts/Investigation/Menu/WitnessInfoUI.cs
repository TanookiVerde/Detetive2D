using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WitnessInfoUI : MonoBehaviour
{
    [SerializeField] private Storage storage;

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image icon;

    public void Hide()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }
    public void SetObject(WitnessData witness)
    {
        GetComponent<CanvasGroup>().alpha = 1;
        string fullDescription = "";
        fullDescription += "IDADE: " + witness.age + "\n";
        fullDescription += "PROFISSÃO: " + witness.job + "\n";
        fullDescription += "RUMORES:";
        Files files = Files.Load();

        int witnessIndex = storage.GetWitnessIndexFromData(witness);
        foreach (Rumor r in files.rumors)
        {
            if (r.target == witnessIndex)
            {
                RumorData rd = storage.GetRumorData(r);
                print(r.from + "/" + r.target) ;
                fullDescription += "\n" + "* " + rd.from.witnessName + ": " + rd.description;
            }
        }
        description.text = fullDescription;
        title.text = witness.witnessName;
        icon.sprite = witness.image;
    }
}
