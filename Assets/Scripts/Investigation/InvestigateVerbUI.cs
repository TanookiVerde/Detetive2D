using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateVerbUI : MonoBehaviour
{
    public static void Show()
    {
        FindObjectOfType<InvestigateVerbUI>().GetComponent<CanvasGroup>().alpha = 1;
    }
    public static void Hide()
    {
        FindObjectOfType<InvestigateVerbUI>().GetComponent<CanvasGroup>().alpha = 0;
    }
}
