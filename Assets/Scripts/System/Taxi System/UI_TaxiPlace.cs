using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_TaxiPlace : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private Image icon;

    private TaxiPlaceData data;

    public void SetInfo(TaxiPlaceData data)
    {
        this.data = data;
        title.text = data._name;
        icon.sprite = data.icon;
        icon.color = data.color;
    }
    public void Travel()
    {
        FindObjectOfType<UI_TaxiMenu>().GetComponent<MenuBehaviour>().Close();
        TravelManager.Travel(data);
    }
}
