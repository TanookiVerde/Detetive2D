using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiSpot : MonoBehaviour
{
    public void OpenTaxiMenu() {
        FindObjectOfType<UI_TaxiMenu>().Open();
    }
}
