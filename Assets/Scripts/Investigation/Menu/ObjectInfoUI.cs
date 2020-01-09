using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ObjectInfoUI : MonoBehaviour
{
    [SerializeField] private Storage storage;

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image icon;

    public void Hide() {
        GetComponent<CanvasGroup>().alpha = 0;
    }
    public void SetObject(ClueData clue)
    {
        GetComponent<CanvasGroup>().alpha = 1;
        string fullDescription = clue.clueDescription;
        Files files = Files.Load();
        int clueIndex = storage.GetClueIndexFromData(clue);
        fullDescription += "\n\nTESTEMUNHOS:";
        foreach (Testimony t in files.testimonys)
        {
            if(t.clue == clueIndex)
            {
                TestimonyData td = storage.GetTestimonyData(t);
                fullDescription += "\n" + "* " + td.witness.witnessName + ": " + td.description;
            }
        }
        fullDescription += "\n\nINSIGHTS:";
        foreach (int i in files.insights)
        {
            InsightData id = storage.GetInsightData(i);
            if ((storage.GetClueIndexFromData(id.firstClue) == clueIndex)
                || (storage.GetClueIndexFromData(id.secondClue) == clueIndex))
            {
                fullDescription += "\n* ["+ id.firstClue.clueName+":"+id.secondClue.clueName+"]" 
                    + id.description;
            }
        }
        description.text = fullDescription;
        title.text = clue.clueName;
        icon.sprite = clue.img;
    }
}
