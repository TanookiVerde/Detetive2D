using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var dialogSpot = collision.gameObject.GetComponent<DialogSpot>();
        if (dialogSpot != null)
        {
            bool available = (dialogSpot.oneTimeOnly && !dialogSpot.played)|| !dialogSpot.oneTimeOnly;
            if (dialogSpot.autoStart && available)
            {
                DialogUI.StartDialog(dialogSpot.data, false);
                dialogSpot.Play();
            }
            else if(!dialogSpot.autoStart)
            {
                VerbUI.Show(VerbType.ASK);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DialogSpot>() != null)
        {
            VerbUI.Hide(VerbType.ASK);
        }
    }
}
