using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueListUI : MonoBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private GameObject cluePrefab;

    [SerializeField] private ClueSpaceUI caller;

    public void Open()
    {
        var cg = GetComponent<CanvasGroup>();
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void Close()
    {
        if(caller!=null)
            caller.GetComponent<Button>().Select();
        caller = null;
        var cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
    public void ListAllCollectedClues(ClueSpaceUI caller)
    {
        CaseData openedCase = InvestigationManager.GetCase();

        Open();
        Erase();
        Files files = Files.Load();
        this.caller = caller;
        var l = files.clues;
        for(int i = 0; i < l.Count;i++)
        {
            var clue = l[i];
            ClueData cd = openedCase.GetClueData(clue);
            var go = Instantiate(cluePrefab, root);
            go.GetComponent<ClueForListUI>().SetInfo(cd);
            go.GetComponent<Button>().onClick.AddListener(
                delegate {
                    ClueData c = cd;
                    Choose(c); 
                });
            if (i == 0)
                go.GetComponent<Button>().Select();
        }
    }
    private void Erase()
    {
        for (int i = root.childCount - 1; i >= 0; i--)
        {
            print(i);
            Destroy(root.GetChild(i).gameObject);
        }
    }
    public void Choose(ClueData cd)
    {
        caller.SelectClue(cd);
        Close();
    }
}
