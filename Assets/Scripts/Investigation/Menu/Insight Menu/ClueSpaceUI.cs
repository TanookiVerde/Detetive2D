using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueSpaceUI : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private Image icon;

    public ClueData selectedClue;

    public void Initialize()
    {
        transform.GetChild(0).GetComponent<CanvasGroup>().alpha = 0;
    }
    public void Active()
    {
        FindObjectOfType<ClueListUI>().ListAllCollectedClues(this);
    }
    public void SelectClue(ClueData clue)
    {
        transform.GetChild(0).GetComponent<CanvasGroup>().alpha = 1;
        selectedClue = clue;
        title.text = clue.clueName;
        icon.sprite = clue.img;
    }
}
