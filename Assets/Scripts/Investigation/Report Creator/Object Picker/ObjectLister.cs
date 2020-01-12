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

    private Coroutine loop;
    private int openedTab;

    public event Choice choiceEvent;
    public delegate void Choice(ScriptableObject selectedObject, DataType type);

    public override void OnOpen()
    {
        OpenTab(0);
        loop = StartCoroutine(Loop());
    }
    public override void OnClose()
    {
        StopCoroutine(loop);
    }
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
                break;
            case DataType.TESTIMONY:
                break;
            case DataType.RUMOR:
                break;
            case DataType.INSIGHT:
                break;
        }
    }
    public void SelectObject(ScriptableObject selectedObject, DataType type)
    {
        choiceEvent.Invoke(selectedObject, type);
        Close();
    }
    private IEnumerator Loop()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                openedTab = Mathf.Clamp(openedTab - 1, 0, 5);
                OpenTab((DataType)openedTab);
            }
            else if (Input.GetKeyDown(KeyCode.E)) {
                openedTab = Mathf.Clamp(openedTab + 1, 0, 5);
                OpenTab((DataType)openedTab);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
                Close();
            yield return null;
        }
    }
    private void Erase()
    {
        for(int i = root.childCount-1; i >= 0; i--)
        {
            Destroy(root.GetChild(i).gameObject);
        }
    }
}
