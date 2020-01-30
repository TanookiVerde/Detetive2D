using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationManager : MonoBehaviour
{
    public static InvestigationManager me;

    public Storage storage;
    public int currentCase;

    public static void SetCase(int caseIndex)
    {
        if (me == null)
            me = FindObjectOfType<InvestigationManager>();
        me.currentCase = caseIndex;

        Files files = Files.Load();
        files.openedCase = caseIndex;
        files.Save();
    }
    public static CaseData GetCase()
    {
        if (me == null)
            me = FindObjectOfType<InvestigationManager>();
        if (me.currentCase >= 0)
            return me.storage.cases[me.currentCase];
        else
            return null;
    }
    public static bool HasActiveCase()
    {
        if (me == null)
            me = FindObjectOfType<InvestigationManager>();
        return me.currentCase >= 0;
    }
}
