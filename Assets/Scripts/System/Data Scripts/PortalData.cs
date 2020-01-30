using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/City/Portal")]
public class PortalData : ScriptableObject
{
    public Scenarios target;
    public Vector2 targetScenePosition;
}
public enum Scenarios
{
    OFFICE = 0, MAIN_CITY = 1, MONTANA_VILLAGE = 2, MARIA_HOUSE = 3, DOMINIC_HOUSE = 7
}
