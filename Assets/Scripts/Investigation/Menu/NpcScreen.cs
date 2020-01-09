using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcScreen : FilesMenuScreen
{
    [SerializeField] private Storage storage;
    [SerializeField] private Transform contentRoot;
    [SerializeField] private GameObject witnessPrefab;

    public string screenName;
    public override void OnShow()
    {
        FindObjectOfType<WitnessInfoUI>().Hide();
        FindObjectOfType<FilesMenu>().SetName(": " + screenName);
        Erase();
        Files files = Files.Load();

        for (int i = 0; i < files.witnesses.Count; i++)
        {
            var go = Instantiate(witnessPrefab, contentRoot);
            go.GetComponent<WitnessUI>().SetInfo(storage.witnesses[files.witnesses[i]]);
            if (i == 0)
                go.GetComponent<Selectable>().Select();
        }
    }
    private void Erase()
    {
        for (int i = contentRoot.childCount - 1; i >= 0; i--)
        {
            Destroy(contentRoot.GetChild(i).gameObject);
        }
    }
}
