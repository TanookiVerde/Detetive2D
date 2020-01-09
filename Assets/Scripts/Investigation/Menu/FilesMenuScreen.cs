using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class FilesMenuScreen : MonoBehaviour
{
    private const float DURATION = 0.5f;

    [SerializeField] private RectTransform rect;
    [SerializeField] private CanvasGroup canvasGroup;

    public void Show(int bias, float duration = DURATION)
    {
        rect.DOAnchorPosX(-1280*bias, 0f);
        rect.DOAnchorPosX(0, duration);
        OnShow();
    }
    public virtual void OnShow()
    {
        canvasGroup.interactable = true;
    }
    public void Hide(int bias, float duration = DURATION)
    {
        rect.DOAnchorPosX(0, 0);
        rect.DOAnchorPosX(-1280 * bias, duration);
        OnHide();
    }
    public virtual void OnHide()
    {
        canvasGroup.interactable = false;
    }
}
