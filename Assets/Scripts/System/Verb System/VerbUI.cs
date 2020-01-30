using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class VerbUI : MonoBehaviour
{
    private const float OPENED_Y = 50;
    private const float CLOSED_Y = -50;

    [SerializeField] private RectTransform rect;
    [SerializeField] private TMP_Text header;
    [SerializeField] private List<VerbType> types;

    public static void Show(VerbType type)
    {
        var verbUi = FindObjectOfType<VerbUI>();
        verbUi.types.Add(type);

        verbUi.header.text = verbUi.GetTextFromType(verbUi.GetFirstOfTheList());
        verbUi.Show();
    }
    public static void Hide(VerbType type)
    {
        var verbUi = FindObjectOfType<VerbUI>();
        verbUi.types.Remove(type);

        if (verbUi.types.Count == 0)
            verbUi.Hide();
        else
            verbUi.header.text = verbUi.GetTextFromType(verbUi.GetFirstOfTheList());
    }
    private void Show()
    {
        rect.DOAnchorPosY(OPENED_Y, 0.25f);
        GetComponent<CanvasGroup>().DOFade(1, 0.25f);
    }
    private void Hide()
    {
        rect.DOAnchorPosY(CLOSED_Y, 0.25f);
        GetComponent<CanvasGroup>().DOFade(0, 0.25f);
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
