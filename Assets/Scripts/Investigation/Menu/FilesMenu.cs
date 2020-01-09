using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FilesMenu : MonoBehaviour
{
    public Storage storage;

    private const string MENU_BASE_NAME = "ARQUIVOS";

    [SerializeField] private TMP_Text header;

    [SerializeField] private List<FilesMenuScreen> screens;
    [SerializeField] private int selectedScreen = 0;
    public bool opened;

    [SerializeField] private CanvasGroup canvasGroup;

    private void Update()
    {
        if (!opened && Input.GetKeyDown(KeyCode.Escape))
            Open();
        else if (opened && Input.GetKeyDown(KeyCode.Escape))
            Close();
        if (Input.GetKeyDown(KeyCode.Q))
            NextScreen(-1);
        if (Input.GetKeyDown(KeyCode.E))
            NextScreen(+1);
    }
    public void Open()
    {
        GlobalFlags.filesMenuOpened = true;
        opened = true;
        header.text = "";
        selectedScreen = 0;
        canvasGroup.DOFade(1, 0);
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        foreach (var s in screens)
            s.Hide(1, 0);
        screens[selectedScreen].Show(1,0);
    }
    public void NextScreen(int direction)
    {
        int index = Mathf.Clamp(selectedScreen + direction, 0, screens.Count-1);
        if (index == selectedScreen)
            return;
        screens[selectedScreen].Hide(direction);
        selectedScreen = index;
        screens[selectedScreen].Show(-direction);
    }
    public void Close()
    {
        GlobalFlags.filesMenuOpened = false;
        opened = false;
        canvasGroup.DOFade(0, 0);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
    public void SetName(string name)
    {
        StartCoroutine(ChangeNameAnimation(name));
    }
    private IEnumerator ChangeNameAnimation(string name)
    {
        header.text = "";
        while (header.text.Length < (MENU_BASE_NAME+name).Length)
        {
            header.text = (MENU_BASE_NAME + name).Substring(0, header.text.Length + 1);
            yield return new WaitForSeconds(0.025f);
        }
    }
}
