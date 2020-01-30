using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class SelectionUI : MonoBehaviour
{
    [SerializeField] private RectTransform rect;

    [SerializeField] private TMP_Text header;
    [SerializeField] private TMP_Text objName;
    [SerializeField] private Image objIcon;

    public bool opened;

    private void Start()
    {
        if (InvestigationManager.HasActiveCase())
        {
            UpdateSelection();
            SetSelectionUIActive(true,0);
        }
        else
            SetSelectionUIActive(false, 0);
    }
    private void Update()
    {
        if (InvestigationManager.HasActiveCase())
        {
            if (InputSeeker.seekers.Count > 1)
                return;
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                InteractionManager.selection.ChangeType();
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                InteractionManager.selection.Shift(-1);
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                InteractionManager.selection.Shift(1);
                UpdateSelection();
            }
        }
    }
    public void UpdateSelection()
    {
        CaseData openedCase = InvestigationManager.GetCase();

        if (InteractionManager.selection.type == SelectionType.CLUE)
        {
            if(!opened) SetSelectionUIActive(true);
            header.text = "PISTA";
            objName.text = openedCase.clues[InteractionManager.selection.clue].clueName;
            objIcon.sprite = openedCase.clues[InteractionManager.selection.clue].img;
        }
        else if (InteractionManager.selection.type == SelectionType.WITNESS)
        {
            if (!opened) SetSelectionUIActive(true);
            header.text = "TESTEMUNHA";
            objName.text = openedCase.witnesses[InteractionManager.selection.witness].witnessName;
            objIcon.sprite = openedCase.witnesses[InteractionManager.selection.witness].image;
        }
        else if (InteractionManager.selection.type == SelectionType.NONE)
        {
            if (opened) SetSelectionUIActive(false);
            //header.text = "SEM SELEÇÃO";
            //objName.text = "NONE";
            //objIcon.sprite = null;
        }
    }
    private void SetSelectionUIActive(bool enabled, float duration = 0.25f)
    {
        opened = enabled;
        int bias = enabled ? 0 : -90;
        rect.DORotate(Vector3.forward * bias, duration);

        var cg = GetComponent<CanvasGroup>();
        cg.DOFade(enabled ? 1 : 0, duration);
        cg.interactable = enabled;
        cg.blocksRaycasts = enabled;

        UpdateSelection();
    }
}
