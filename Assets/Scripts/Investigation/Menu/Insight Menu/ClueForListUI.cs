using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClueForListUI : MonoBehaviour
{
    [SerializeField] private TMP_Text name;
    [SerializeField] private Image icon;
    [SerializeField] private ClueData clueData;

    public void SetInfo(ClueData cd)
    {
        clueData = cd;
        name.text = cd.clueName;
        icon.sprite = cd.img;
    }
}
