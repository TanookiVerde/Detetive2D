using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerbUI : MonoBehaviour
{
    [SerializeField] private TMP_Text header;
    [SerializeField] private List<VerbType> types;

    public static void Show(VerbType type)
    {
        var verbUi = FindObjectOfType<VerbUI>();
        verbUi.types.Add(type);

        verbUi.header.text = verbUi.GetTextFromType(verbUi.GetFirstOfTheList());
        verbUi.GetComponent<CanvasGroup>().alpha = 1;
    }
    public static void Hide(VerbType type)
    {
        var verbUi = FindObjectOfType<VerbUI>();
        verbUi.types.Remove(type);

        if (verbUi.types.Count == 0)
            verbUi.GetComponent<CanvasGroup>().alpha = 0;
        else
            verbUi.header.text = verbUi.GetTextFromType(verbUi.GetFirstOfTheList());
    }
    private VerbType GetFirstOfTheList()
    {
        return types[0];
    }
    private string GetTextFromType(VerbType type)
    {
        switch (type)
        {
            case VerbType.INVESTIGATE:
                return "[X] Investigar";
            case VerbType.OPEN:
                return "[X] Entrar";
            case VerbType.LOOK:
                return "[X] Olhar";
            case VerbType.CLIMB:
                return "[X] Subir";
            case VerbType.ASK:
                return "[X] Questionar";
            default:
                return "Error";
        }
    }
}
public enum VerbType
{
    INVESTIGATE, OPEN, LOOK, CLIMB, ASK
}
