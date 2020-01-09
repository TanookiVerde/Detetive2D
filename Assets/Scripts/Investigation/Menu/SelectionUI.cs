using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectionUI : MonoBehaviour
{
    [SerializeField] private Storage storage;

    [SerializeField] private TMP_Text header;
    [SerializeField] private TMP_Text objName;
    [SerializeField] private Image objIcon;

    private void Start()
    {
        UpdateSelection();
    }
    private void Update()
    {
        if (GlobalFlags.filesMenuOpened == true)
            return;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InteractionManager.selection.ChangeType();
            UpdateSelection();
        }else if (Input.GetKeyDown(KeyCode.Q))
        {
            InteractionManager.selection.Shift(-1);
            UpdateSelection();
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionManager.selection.Shift(1);
            UpdateSelection();
        }
    }
    public void UpdateSelection()
    {
        if (InteractionManager.selection.type == SelectionType.CLUE)
        {
            transform.GetChild(1).GetComponent<CanvasGroup>().alpha = 1;
            header.text = "PISTA";
            objName.text = storage.clues[InteractionManager.selection.clue].clueName;
            objIcon.sprite = storage.clues[InteractionManager.selection.clue].img;
        }
        else if (InteractionManager.selection.type == SelectionType.WITNESS)
        {
            transform.GetChild(1).GetComponent<CanvasGroup>().alpha = 1;
            header.text = "TESTEMUNHA";
            objName.text = storage.witnesses[InteractionManager.selection.witness].witnessName;
            objIcon.sprite = storage.witnesses[InteractionManager.selection.witness].image;
        }
        else if (InteractionManager.selection.type == SelectionType.NONE)
        {
            transform.GetChild(1).GetComponent<CanvasGroup>().alpha = 0;
            header.text = "SEM SELEÇÃO";
            objName.text = "NONE";
            objIcon.sprite = null;
        }
    }
}
