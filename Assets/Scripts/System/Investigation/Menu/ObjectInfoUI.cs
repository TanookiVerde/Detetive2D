using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ObjectInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image icon;

    public void Hide() {
        GetComponent<CanvasGroup>().alpha = 0;
    }
    public void SetObject(ClueData clue, bool full = true)
    {
        CaseData openedCase = InvestigationManager.GetCase();

        GetComponent<CanvasGroup>().alpha = 1;
        string fullDescription = clue.clueDescription;
        Files files = Files.Load();

        if (full)
        {
            int clueIndex = openedCase.GetClueIndexFromData(clue);
            fullDescription += "\n\nTESTEMUNHOS:";
            foreach (Testimony t in files.GetCaseStatus().testimonys)
            {
                if (t.clue == clueIndex)
                {
                    TestimonyData td = openedCase.GetTestimonyData(t);
                    fullDescription += "\n" + "* " + td.witness.witnessName + ": " + td.description;
                }
            }
            fullDescription += "\n\nINSIGHTS:";
            foreach (int i in files.GetCaseStatus().insights)
            {
                InsightData id = openedCase.GetInsightData(i);
                if ((openedCase.GetClueIndexFromData(id.firstClue) == clueIndex)
                    || (openedCase.GetClueIndexFromData(id.secondClue) == clueIndex))
                {
                    fullDescription += "\n* [" + id.firstClue.clueName + ":" + id.secondClue.clueName + "]"
                        + id.description;
                }
            }
        }
        description.text = fullDescription;
        title.text = clue.clueName;
        icon.sprite = clue.img;
    }
    public void SetObject(WitnessData data)
    {
        GetComponent<CanvasGroup>().alpha = 1;
        description.text = data.witnessName;//rumores com ela como alvo
        title.text = data.witnessName;
        icon.sprite = data.image;
    }
    public void SetObject(InsightData data)
    {
        GetComponent<CanvasGroup>().alpha = 1;
        description.text = data.description;
        title.text = data.firstClue.clueName + " + " + data.secondClue.clueName;
        //icon.sprite = data.image;
    }
    public void SetObject(TestimonyData data)
    {
        GetComponent<CanvasGroup>().alpha = 1;
        description.text = data.description;
        title.text = data.witness.witnessName + ": " + data.clue.clueName;
        //icon.sprite = data.image;
    }
    public void SetObject(RumorData data)
    {
        GetComponent<CanvasGroup>().alpha = 1;
        description.text = data.description;
        title.text = data.from.witnessName + ": " + data.target.witnessName;
        //icon.sprite = data.image;
    }
}
