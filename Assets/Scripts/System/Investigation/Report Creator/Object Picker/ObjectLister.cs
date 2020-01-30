using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ObjectLister : MenuBehaviour
{
    [Header("Allow objects of type")]
    public bool clues;
    public bool testimonys;
    public bool rumors;
    public bool witnesses;
    public bool insights;

    [SerializeField] private TMP_Text tabTitle;
    [SerializeField] private Transform root;
    [SerializeField] private GameObject objectPrefab;

    public ObjectInfoUI objectInfo;
    private int openedTab;
    private bool[] allowed = new bool[5];

    public event Choice choiceEvent;
    public delegate void Choice(ScriptableObject selectedObject, DataType type);

    public override void OnOpen()
    {
        OpenTab(0);
    }
    public override void OnClose(){}
    private void OpenTab(DataType type)
    {
        tabTitle.text = "" + type;
        openedTab = (int) type;
        Erase();
        switch (type)
        {
            case DataType.CLUE:
                List<ClueData> clues = InvestigationManager.GetCase().ListAllCluesIn(Files.Load());
                for (int i = 0; i < clues.Count;i++)
                {
                    var go = Instantiate(objectPrefab, root);
                    go.GetComponent<ListedObject>().SetInfo(clues[i]);
                    if (i == 0) 
                        go.GetComponent<Selectable>().Select();
                }
                break;
            case DataType.WITNESS:
                List<WitnessData> witness = InvestigationManager.GetCase().ListAllWitnessIn(Files.Load());
                for (int i = 0; i < witness.Count; i++)
                {
                    var go = Instantiate(objectPrefab, root);
                    go.GetComponent<ListedObject>().SetInfo(witness[i]);
                    if (i == 0)
                        go.GetComponent<Selectable>().Select();
                }
                break;
            case DataType.TESTIMONY:
                List<TestimonyData> testimony = InvestigationManager.GetCase().ListAllTestimonyIn(Files.Load());
                for (int i = 0; i < testimony.Count; i++)
                {
                    var go = Instantiate(objectPrefab, root);
                    go.GetComponent<ListedObject>().SetInfo(testimony[i]);
                    if (i == 0)
                        go.GetComponent<Selectable>().Select();
                }
                break;
            case DataType.RUMOR:
                List<RumorData> rumor = InvestigationManager.GetCase().ListAllRumorIn(Files.Load());
                for (int i = 0; i < rumor.Count; i++)
                {
                    var go = Instantiate(objectPrefab, root);
                    go.GetComponent<ListedObject>().SetInfo(rumor[i]);
                    if (i == 0)
                        go.GetComponent<Selectable>().Select();
                }
                break;
            case DataType.INSIGHT:
                List<InsightData> insight = InvestigationManager.GetCase().ListAllInsightIn(Files.Load());
                for (int i = 0; i < insight.Count; i++)
                {
                    var go = Instantiate(objectPrefab, root);
                    go.GetComponent<ListedObject>().SetInfo(insight[i]);
                    if (i == 0)
                        go.GetComponent<Selectable>().Select();
                }
                break;
        }
    }
    public void SelectObject(ScriptableObject selectedObject, DataType type)
    {
        choiceEvent.Invoke(selectedObject, type);
        Close();
    }
    public override void Loop()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenTab((DataType)GetNextAllowedTab(openedTab, -1));
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
            OpenTab((DataType)GetNextAllowedTab(openedTab, 1));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Close();
    }
    private void Erase()
    {
        for(int i = root.childCount-1; i >= 0; i--)
        {
            Destroy(root.GetChild(i).gameObject);
        }
    }
    private bool[] GetAllowedObjects()
    {
        var b = new bool[5];
        b[0] = clues;
        b[1] = witnesses;
        b[2] = testimonys;
        b[3] = rumors;
        b[4] = insights;
        return b;
    }
    public void SetAllowedObjects(bool[] b)
    {
        clues = b[0];
        witnesses = b[1];
        testimonys = b[2];
        rumors = b[3];
        insights = b[4];
    }
    private int GetNextAllowedTab(int current, int direction)
    {
        var allowed = GetAllowedObjects();
        for(int i = current + direction; i >= 0 && i < allowed.Length; i += direction)
        {
            if (allowed[i])
                return i;
        }
        return current;
    }
}
