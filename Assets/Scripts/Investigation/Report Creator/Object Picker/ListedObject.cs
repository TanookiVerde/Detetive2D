using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ListedObject : MonoBehaviour, ISelectHandler
{
    [SerializeField] private TMP_Text title;
    private ScriptableObject obj;
    private DataType type;

    public void SetInfo(ClueData data)
    {
        title.text = data.clueName;
        obj = data;
        type = DataType.CLUE;
    }
    public void SetInfo(WitnessData data)
    {
        title.text = data.witnessName;
        obj = data;
        type = DataType.WITNESS;
    }
    public void SetInfo(TestimonyData data)
    {
        title.text = data.witness.witnessName + ": " + data.clue.clueName;
        obj = data;
        type = DataType.TESTIMONY;
    }
    public void SetInfo(RumorData data)
    {
        title.text = data.from.witnessName + " sobre " + data.target.witnessName;
        obj = data;
        type = DataType.RUMOR;
    }
    public void SetInfo(InsightData data)
    {
        title.text = data.firstClue.clueName + "+" + data.secondClue.clueName;
        obj = data;
        type = DataType.INSIGHT;
    }
    public void Select()
    {
        FindObjectOfType<ObjectLister>().SelectObject(obj, type);
    }
    public void OnSelect(BaseEventData eventData)
    {
        switch (type)
        {
            case DataType.CLUE:
                FindObjectOfType<ObjectLister>().objectInfo.SetObject((ClueData)obj, false);
                break;
            case DataType.WITNESS:
                FindObjectOfType<ObjectLister>().objectInfo.SetObject((WitnessData)obj);
                break;
            case DataType.TESTIMONY:
                FindObjectOfType<ObjectLister>().objectInfo.SetObject((TestimonyData)obj);
                break;
            case DataType.RUMOR:
                FindObjectOfType<ObjectLister>().objectInfo.SetObject((RumorData)obj);
                break;
            case DataType.INSIGHT:
                FindObjectOfType<ObjectLister>().objectInfo.SetObject((InsightData)obj);
                break;
        }
    }
}
