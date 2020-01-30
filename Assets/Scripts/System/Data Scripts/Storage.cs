using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Storage")]
public class Storage : ScriptableObject
{
    public List<CaseData> cases;
    public List<InvestigationSpot> spots;
    public List<TaxiPlaceData> taxiPlaces;
}
