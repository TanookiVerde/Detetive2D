using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private PortalData data;

    public void EnterPortal()
    {
        FindObjectOfType<TravelManager>().Travel(data);
    }
}
