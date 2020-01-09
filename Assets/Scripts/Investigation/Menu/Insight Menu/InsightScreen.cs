using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsightScreen : FilesMenuScreen
{
    public Storage storage;
    public string screenName;
    public ClueListUI clueList;

    public ClueSpaceUI firstSpace;
    public ClueSpaceUI secondSpace;
    
    public override void OnShow()
    {
        FindObjectOfType<FilesMenu>().SetName(": " + screenName);
        clueList.Close();
        firstSpace.Initialize();
        secondSpace.Initialize();
        firstSpace.GetComponent<Selectable>().Select();
        base.OnShow();
    }
    public override void OnHide()
    {
        base.OnHide();
    }
    public void Relate()
    {
        var clue1 = firstSpace.selectedClue;
        var clue2 = secondSpace.selectedClue;
        foreach(InsightData i in storage.insights)
        {
            if((i.firstClue == clue1 && i.secondClue == clue2) 
                || (i.firstClue == clue2 && i.secondClue == clue1))
            {
                int insightIndex = storage.GetInsightIndexFromData(i);
                Files file = Files.Load();
                bool added = file.AddInsight(insightIndex);
                file.Save();
                DialogUI.StartDialog(i.findingDialog, added, DialogType.INSIGHT);
                return;
            }
        }
        List<string> s = new List<string>();
        s.Add("Humm, não consegui ver nenhuma relação direta entre as pistas.");
        DialogUI.StartDialog(s);
    }
}
