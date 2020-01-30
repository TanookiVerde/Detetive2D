using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/InvestigationSpot/CaseSpot")]
public class CaseInvestigationSpotData : InvestigationSpotData
{
    public CaseSpot caseFile;

    public override void Investigate(Vector2 normalizedPosition)
    {
        if ((normalizedPosition - caseFile.position).magnitude <= caseFile.colliderSize)
        {
            FoundCase(caseFile.caseData);
            return;
        }
        NoClueFound();
    }
}
