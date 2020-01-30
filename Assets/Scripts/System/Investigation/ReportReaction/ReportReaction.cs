using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ReportReaction : MonoBehaviour
{
    private const float DURATION = 0.7f;

    public ReactionData successfulReaction;
    public ReactionData failureReaction;

    public Color successColor;
    public Color failureColor;

    [SerializeField] private Image canvas;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private TMP_Text title;
    [SerializeField] private Image background;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            FindObjectOfType<ReportReaction>().Begin(true);
        if (Input.GetKeyDown(KeyCode.T))
            FindObjectOfType<ReportReaction>().Begin(false);
    }
    public void Begin(bool success)
    {
        StartCoroutine(Animation(success));
    }
    private IEnumerator Animation(bool success)
    {
        ReactionData r = success ? successfulReaction : failureReaction;
        Color c = success ? successColor : failureColor;
        group.DOFade(1, DURATION / 2);
        canvas.DOFade(0, 0);
        title.DOFade(0, 0);
        title.transform.DOScale(0, 0);
        title.text = success ? "APROVADO!" : "REPROVADO...";
        background.DOColor(Color.black, 0);

        yield return new WaitForSeconds(DURATION / 2);

        for (int i = 0; i < r.sequence.Count; i++)
        {
            canvas.DOFade(0, 0);
            canvas.transform.DOScale(0.5f, 0);
            canvas.DOFade(1, DURATION/4);
            canvas.transform.DOScale(1.25f, DURATION/2);
            yield return null;
            canvas.sprite = r.sequence[i];
            if (i == r.sequence.Count - 1)
            {
                background.DOColor(c, DURATION/4);
                title.DOFade(1, DURATION / 4);
                title.transform.DOScale(1, DURATION / 4);
                yield return new WaitForSeconds(DURATION * 1.5f);
            }
            else
            {
                yield return new WaitForSeconds(DURATION * 1.5f);
                canvas.DOFade(0, 0);
                canvas.transform.DOScale(0, 0);
            }
        }
        yield return new WaitForSeconds(2f);
        group.DOFade(0, DURATION / 2);
    }
}
