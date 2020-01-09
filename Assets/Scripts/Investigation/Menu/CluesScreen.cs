using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesScreen : FilesMenuScreen
{
    [SerializeField] private Storage storage;
    [SerializeField] private Transform contentRoot;
    [SerializeField] private GameObject cluePrefab;

    public string screenName;
    public override void OnShow()
    {
        base.OnShow();
        FindObjectOfType<FilesMenu>().SetName(": " + screenName);
        FindObjectOfType<ObjectInfoUI>().Hide();
        Erase();
        Files files = Files.Load();

        for(int i = 0; i < files.clues.Count; i++)
        {
            var go = Instantiate(cluePrefab, contentRoot);
            go.GetComponent<ClueFilesMenu>().SetInfo(storage.clues[files.clues[i]]);
            if (i == 0)
                go.GetComponent<Selectable>().Select();
        }
    }
    public override void OnHide()
    {
        base.OnHide();
    }
    private void Erase()
    {
        for(int i = contentRoot.childCount-1; i >= 0; i--)
        {
            Destroy(contentRoot.GetChild(i).gameObject);
        }
    }
}
