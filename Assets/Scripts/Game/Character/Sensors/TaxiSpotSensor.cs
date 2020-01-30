using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiSpotSensor : MonoBehaviour
{
    public List<TaxiSpot> collidingTaxiSpot = new List<TaxiSpot>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var portal = collision.GetComponent<TaxiSpot>();
        if (portal != null)
        {
            VerbUI.Show(VerbType.OPEN);
            collidingTaxiSpot.Add(portal);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var portal = collision.GetComponent<TaxiSpot>();
        if (portal != null)
        {
            VerbUI.Hide(VerbType.OPEN);
            collidingTaxiSpot.Remove(portal);
        }
    }
    public void OpenTaxiMenu()
    {
        collidingTaxiSpot[0].OpenTaxiMenu();
    }
}
