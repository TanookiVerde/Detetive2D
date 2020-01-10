using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationSpot : MonoBehaviour
{
    [SerializeField] private InvestigationSpotData data;

    public void OpenInvestigationSpot()
    {
        FindObjectOfType<InvestigationSpotUI>().Open(data);
    }
}
