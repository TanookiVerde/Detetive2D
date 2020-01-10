using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationSpotSensor : MonoBehaviour
{
    public List<InvestigationSpot> collidingSpots = new List<InvestigationSpot>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var spot = collision.GetComponent<InvestigationSpot>();
        if (spot != null)
        {
            VerbUI.Show(VerbType.LOOK);
            collidingSpots.Add(spot);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var spot = collision.GetComponent<InvestigationSpot>();
        if (spot != null)
        {
            VerbUI.Hide(VerbType.LOOK);
            collidingSpots.Remove(spot);
        }
    }
    public void OpenInvestigationSpot()
    {
        collidingSpots[0].OpenInvestigationSpot();
    }
}
