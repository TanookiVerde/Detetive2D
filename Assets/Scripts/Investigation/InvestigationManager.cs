using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationManager : MonoBehaviour
{
    public static InvestigationManager me;

    public Storage storage;
    public int currentCase;

    public void Start()
    {
        me = this;
    }
    public static CaseData GetCase()
    {
        return me.storage.cases[me.currentCase];
    }
}
