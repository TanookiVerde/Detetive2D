using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/InvestigationSpot/Spot")]
public class InvestigationSpotData : ScriptableObject
{
    public Sprite background;
    public List<ClueSpot> clues;

}
[System.Serializable]
public class ClueSpot
{
    public Vector2 position;
    public ClueData clue;
    public float colliderSize;
}
