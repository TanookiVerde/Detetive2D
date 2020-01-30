using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationSpot : MonoBehaviour
{
    [SerializeField] private InvestigationSpotData data;

    public void OpenInvestigationSpot()
    {
        var iSpot = FindObjectOfType<InvestigationSpotUI>();
        iSpot.SetInfo(data);
        iSpot.Open();
    }
    public int GetCase()
    {
        Storage s = InvestigationManager.me.storage;
        for (int i = 0; i < s.cases.Count; i++)
        {
            for (int j = 0; j < s.cases[i].spots.Count; j++)
            {
                if (s.cases[i].spots[j] == data)
                    return i;
            }
        }
        return -1;
    }
}
