using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClueFilesMenu : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text header;
    [SerializeField] private ClueData data;

    public void SetInfo(ClueData data)
    {
        this.data = data;
        this.icon.sprite = data.img;
        this.header.text = data.clueName;
    }
    public void Select()
    {
        FindObjectOfType<ObjectInfoUI>().SetObject(data);
    }
}
