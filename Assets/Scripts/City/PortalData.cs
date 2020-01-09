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
    MAIN_CITY = 0, JOHN_HOUSE = 1
}
