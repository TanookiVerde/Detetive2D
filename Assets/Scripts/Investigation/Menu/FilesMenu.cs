﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FilesMenu : MenuBehaviour
{
    private const string MENU_BASE_NAME = "ARQUIVOS";

    [SerializeField] private TMP_Text header;
    [SerializeField] private List<FilesMenuScreen> screens;

    private int selectedScreen = 0;
    private Coroutine changeName;
    private Coroutine loop;

    public bool opened;

    public void Start()
    {
        foreach (var s in screens)
            s.Hide(1, 0);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !opened)
            Open();
        else if (Input.GetKeyDown(KeyCode.Escape) && opened && canvasGroup.interactable)
            Close();
    }
    public override void OnOpen()
    {
        opened = true;
        header.text = "";
        selectedScreen = 1;
        foreach (var s in screens)
            s.Hide(1, 0);
        screens[selectedScreen].Show(1, 0);
        loop = StartCoroutine(Loop());
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
    public override void OnClose()
    {
        opened = false;
        StopCoroutine(loop);
    }
    public void SetName(string name)
    {
        if (changeName != null)
            StopCoroutine(changeName);
        changeName = StartCoroutine(ChangeNameAnimation(name));
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
    private IEnumerator Loop()
    {
        yield return null;
        while (true)
        {
            if (canvasGroup.interactable)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                    NextScreen(-1);
                if (Input.GetKeyDown(KeyCode.E))
                    NextScreen(+1);
            }
            yield return null;
        }
    }
}
