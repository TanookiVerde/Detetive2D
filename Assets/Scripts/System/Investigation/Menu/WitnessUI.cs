using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WitnessUI : MonoBehaviour
{
    [SerializeField] private TMP_Text witnessName;
    [SerializeField] private TMP_Text age;
    [SerializeField] private TMP_Text job;
    [SerializeField] private Image icon;

    private WitnessData witnessData;

    public void SetInfo(WitnessData data)
    {
        witnessData = data;
        witnessName.text = data.witnessName;
        age.text = data.age + " anos";
        job.text = data.job;
        icon.sprite = data.image;
    }
    public void Select()
    {
        FindObjectOfType<WitnessInfoUI>().SetObject(witnessData);
    }
}
