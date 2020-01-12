using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportCreatorScreen : MonoBehaviour
{
    public virtual void Open()
    {
        var cg = GetComponent<CanvasGroup>();
        cg.interactable = true;
        cg.blocksRaycasts = true;
        cg.alpha = 1;
        OnOpen();
    }
    public virtual void OnOpen(){}
    public virtual void Close()
    {
        var cg = GetComponent<CanvasGroup>();
        cg.interactable = false;
        cg.blocksRaycasts = false;
        cg.alpha = 0;
        OnClose();
    }
    public virtual void OnClose(){}
}
