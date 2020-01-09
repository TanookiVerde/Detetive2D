using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSensor : MonoBehaviour
{
    public List<Portal> collidingPortal = new List<Portal>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var portal = collision.GetComponent<Portal>();
        if (portal != null)
        {
            VerbUI.Show(VerbType.OPEN);
            collidingPortal.Add(portal);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var portal = collision.GetComponent<Portal>();
        if (portal != null)
        {
            VerbUI.Hide(VerbType.OPEN);
            collidingPortal.Remove(portal);
        }
    }
    public void EnterPortal()
    {
        collidingPortal[0].EnterPortal();
    }
}
