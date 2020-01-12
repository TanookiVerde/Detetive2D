using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogContent;
    [SerializeField] private TMP_Text continueIcon;

    public static void StartDialog(DialogData data, bool addedOnFiles = false, DialogType type = DialogType.NONE)
    {
        if (GlobalFlags.dialog) return;
        var dialog = FindObjectOfType<DialogUI>();
        dialog.GetComponent<CanvasGroup>().alpha = 1;
        dialog.StartCoroutine(dialog.DialogScript(data.txts, addedOnFiles, type));
    }
    public static void StartDialog(List<string> speech)
    {
        if (GlobalFlags.dialog) return;
        var dialog = FindObjectOfType<DialogUI>();
        dialog.GetComponent<CanvasGroup>().alpha = 1;
        dialog.StartCoroutine(dialog.DialogScript(speech, false, DialogType.NONE));
    }
    private IEnumerator DialogScript(List<string> speech, bool addedOnFiles, DialogType type)
    {
        GlobalFlags.dialog = true;
        transform.parent.GetComponent<CanvasGroup>().interactable = false; //desativa todos os canvas de interacao
        List<string> txts = new List<string>(speech);
        continueIcon.enabled = false;

        if ((type != DialogType.NONE) && addedOnFiles)
            txts.Add(GetText(type));
        dialogContent.text = "";

        yield return null;

        var dialog = FindObjectOfType<DialogUI>();
        for(int i = 0; i < txts.Count; i++)
        {
            for(int j = 0; j <= txts[i].Length; j++)
            {
                dialogContent.text = txts[i].Substring(0, j);
                yield return new WaitForSeconds(0.01f);
            }
            continueIcon.enabled = true;
            yield return WaitForInput(KeyCode.X, 0);
            continueIcon.enabled = false;
        }
        dialog.GetComponent<CanvasGroup>().alpha = 0;
        GlobalFlags.dialog = false;
        transform.parent.GetComponent<CanvasGroup>().interactable = true;
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
            default:
                return "...";
        }
    }
}
public enum DialogType{
    NONE, CLUE, RUMOR, TESTIMONY, WITNESS, INSIGHT
}
