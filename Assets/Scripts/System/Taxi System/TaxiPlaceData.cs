using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/TaxiPlace")]
public class TaxiPlaceData : ScriptableObject
{
    public string _name;
    public Sprite icon;
    public Color color;

    public int scenarioIndex;
    public Vector2 position;
}
