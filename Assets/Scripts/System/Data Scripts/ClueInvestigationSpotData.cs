using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/InvestigationSpot/ClueSpot")]
public class ClueInvestigationSpotData : InvestigationSpotData
{
    public List<ClueSpot> clues;

    public override void Investigate(Vector2 normalizedPosition)
    {
        foreach (var s in clues)
        {
            if ((normalizedPosition - s.position).magnitude <= s.colliderSize)
            {
                FoundClue(s.clue);
                return;
            }
        }
        NoClueFound();
    }
}
