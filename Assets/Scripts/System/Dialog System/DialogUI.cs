using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DialogUI : InputSeeker
{
    private const float OPENED_Y = -120;
    private const float CLOSED_Y = 120;

    [SerializeField] private RectTransform rect;
    [SerializeField] private TMP_Text dialogContent;
    [SerializeField] private Image continueIcon;

    [SerializeField] private Image speakerIcon;
    [SerializeField] private TMP_Text speakerName;

    [SerializeField] private WitnessData systemWitness;

    public void Open()
    {
        Enter(this);
        rect.DOAnchorPosY(CLOSED_Y, 0);
        rect.DOAnchorPosY(OPENED_Y, 0.25f);
        GetComponent<CanvasGroup>().DOFade(1, 0.25f);
    }
    public void Close()
    {
        Exit();
        rect.DOAnchorPosY(CLOSED_Y, 0.25f);
        GetComponent<CanvasGroup>().DOFade(0, 0.25f);
    }
    public static void StartDialog(DialogData data, bool addedOnFiles = false, DialogType type = DialogType.NONE)
    {
        var dialog = FindObjectOfType<DialogUI>();
        dialog.Open();
        dialog.StartCoroutine(dialog.DialogScript(data, addedOnFiles, type));
    }
    private IEnumerator DialogScript(DialogData data, bool addedOnFiles, DialogType type)
    {
        yield return null;

        List<Speak> d = new List<Speak>(data.dialog);

        if (addedOnFiles && DialogType.NONE != type)
            d.Add(new Speak(GetText(type), systemWitness));

        continueIcon.enabled = false;

        var dialog = FindObjectOfType<DialogUI>();
        for (int i = 0; i < d.Count; i++)
        {
            speakerIcon.sprite = d[i].who.image;
            speakerName.text = d[i].who.witnessName;
            for (int j = 0; j <= d[i].what.Length; j++)
            {
                dialogContent.text = d[i].what.Substring(0, j);
                yield return new WaitForSeconds(0.01f);
            }
            continueIcon.enabled = true;
            yield return WaitForInput(KeyCode.X, 0);
            continueIcon.enabled = false;
        }
        dialog.Close();
    }
    private IEnumerator WaitForInput(KeyCode input, float minTime = 1f)
    {
        yield return new WaitForSeconds(minTime);
        while (!Input.GetKey(input))
            yield return null;
    }
    public string GetText(DialogType type)
    {
        switch (type)
        {
            case DialogType.CLUE:
                return "**Pista adicionado nos ARQUIVOS**";
            case DialogType.RUMOR:
                return "**Rumor adicionado nos ARQUIVOS**";
            case DialogType.TESTIMONY:
                return "**Testemunho adicionado nos ARQUIVOS**";
            case DialogType.WITNESS:
                return "**Dados da testemunha adicionados nos ARQUIVOS**";
            case DialogType.INSIGHT:
                return "**Insight adicionado nos detalhes das pistas, nos ARQUIVOS**";
            case DialogType.CASE:
                return "**Ficha com dados do caso adicionados nos ARQUIVOS**";
            default:
                return "...";
        }
    }
}
public enum DialogType{
    NONE, CLUE, RUMOR, TESTIMONY, WITNESS, INSIGHT, CASE
}
