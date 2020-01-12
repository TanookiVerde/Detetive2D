using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    public static List<MenuBehaviour> menuHierarchy = new List<MenuBehaviour>();
    public CanvasGroup canvasGroup;
    [SerializeField] private Selectable firstSelected;

    public void Open()
    {
        Add(this);

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        if(firstSelected!= null)
            firstSelected.Select();
        OnOpen();
    }
    public void Close()
    {
        Remove(this);
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        OnClose();
    }
    public virtual void OnOpen() { }
    public virtual void OnClose() { }
    public void SetInteractive(bool value)
    {
        canvasGroup.interactable = value;
        if (firstSelected != null)
        {
            firstSelected.Select();
        }
    }
    public static void Add(MenuBehaviour menu)
    {
        foreach (var m in menuHierarchy)
        {
            m.SetInteractive(false);
        }
        menuHierarchy.Add(menu);
        GlobalFlags.menuOpened = menuHierarchy.Count > 0;
    }
    public static void Remove(MenuBehaviour menu)
    {
        menuHierarchy.Remove(menu);
        if(menuHierarchy.Count > 0)
            menuHierarchy[menuHierarchy.Count - 1].SetInteractive(true);
        GlobalFlags.menuOpened = menuHierarchy.Count > 0;
    }
}
