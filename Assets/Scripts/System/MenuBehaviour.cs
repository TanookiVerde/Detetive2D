using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : InputSeeker
{
    public CanvasGroup canvasGroup;
    [SerializeField] private Selectable firstSelected;

    public virtual void Open()
    {
        Enter(this);

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        if(firstSelected!= null)
            firstSelected.Select();
        OnOpen();
    }
    public virtual void Close()
    {
        Exit();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        OnClose();
    }
    public virtual void Loop() { }
    public virtual void OnOpen() { }
    public virtual void OnClose() { }
    public override void OnBack()
    {
        canvasGroup.interactable = true;
        if (firstSelected != null)
            firstSelected.Select();
    }
    public override void OnLeave()
    {
        canvasGroup.interactable = true;
    }
    private void Update()
    {
        if (interactable)
            Loop();
    }
}
