using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueTextUI : MonoBehaviour
{
    private const string ADD_ON_FOLDER_TEXT = "**Adicionado na pasta**";

    [SerializeField] private TMP_Text clueContent;
    [SerializeField] private Image clueIcon;
    public static void ShowClue(ClueData data)
    {
        var clue = FindObjectOfType<ClueTextUI>();
        clue.GetComponent<CanvasGroup>().alpha = 1;
        clue.clueIcon.sprite = data.img;
        clue.StartCoroutine(clue.ClueScript(data));
    }
    private IEnumerator ClueScript(ClueData data)
    {
        GlobalFlags.clue = true;
        var clue = FindObjectOfType<ClueTextUI>();
        for (int j = 0; j <= data.clueDescription.Length; j++)
        {
            clueContent.text = data.clueDescription.Substring(0, j);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2);
        for (int j = 0; j <= ADD_ON_FOLDER_TEXT.Length; j++)
        {
            clueContent.text = ADD_ON_FOLDER_TEXT.Substring(0, j);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1);
        clue.GetComponent<CanvasGroup>().alpha = 0;
        GlobalFlags.clue = false;
    }
}
