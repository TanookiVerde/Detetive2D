using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_TaxiMenu : MenuBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private Transform root;
    [SerializeField] private GameObject taxiPlacePrefab;

    public override void Open()
    {
        Enter(this);

        rect.DOAnchorPosY(-720, 0);
        rect.DOAnchorPosY(0, 0.5f);
        canvasGroup.DOFade(1, 0.5f);

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        OnOpen();
    }
    public override void OnOpen()
    {
        Erase();
        ListAllPlaces();
    }
    public override void Close()
    {
        Exit();

        rect.DOAnchorPosY(-720, 0.5f);
        canvasGroup.DOFade(0, 0.5f);
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        OnClose();
    }
    public override void OnClose() {}
    public void Erase()
    {
        for(int i = root.childCount-1; i >= 0; i--)
        {
            Destroy(root.GetChild(i).gameObject);
        }
    }
    public void ListAllPlaces()
    {
        var places = InvestigationManager.me.storage.taxiPlaces;
        int current = TravelManager.GetCurrentScenario();
        for (int i = 0; i < places.Count; i++)
        {
            var go = Instantiate(taxiPlacePrefab, root);
            go.GetComponent<UI_TaxiPlace>().SetInfo(places[i]);
            go.GetComponent<Button>().interactable = places[i].scenarioIndex != current;
            if (i == 0)
                go.GetComponent<Selectable>().Select();
        }
    }
    public override void Loop()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Close();
    }
}
