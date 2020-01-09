using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    public Storage storage;
    public ClueData clueData;

    public void Investigate()
    {
        Files files = Files.Load();
        bool added = files.AddClue(storage.clues.IndexOf(clueData));
        files.Save();
        DialogUI.StartDialog(clueData.findingDialog, added, DialogType.CLUE);
    }
}
