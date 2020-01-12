using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectPicker : MonoBehaviour
{
    [Header("Allow objects of type")]
    public bool clues;
    public bool testimonys;
    public bool rumors;
    public bool witnesses;
    public bool insights;

    [Space(10)]
    public TMP_Text title;
    public ObjectLister lister;

    private ScriptableObject selectedObject;
    private DataType type;

    public void OpenLister()
    {
        lister.SetAllowedObjects(GetAllowedObjects());
        lister.Open();
        lister.choiceEvent += SetObject;
    }
    public void SetObject(ScriptableObject obj, DataType type)
    {
        title.text = obj.name;
        selectedObject = obj;
        this.type = type;
        lister.choiceEvent -= SetObject;
    }
    public void ResetPicker()
    {
        title.text = "Selecione";
    }
    public ScriptableObject GetSelectedObject()
    {
        return selectedObject;
    }
    public DataType GetSelectedType()
    {
        return type;
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
}
