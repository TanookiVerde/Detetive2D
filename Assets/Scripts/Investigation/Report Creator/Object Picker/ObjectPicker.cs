using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectPicker : MonoBehaviour
{
    public TMP_Text title;
    public ObjectLister lister;

    private ScriptableObject selectedObject;
    private DataType type;

    public void OpenLister()
    {
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
}
