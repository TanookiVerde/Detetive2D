using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Files
{
    private const int CASE_QUANTITY = 4;
    private const string path = "SaveFile.txt";

    public CaseStatus[] status = new CaseStatus[CASE_QUANTITY];

    public int openedCase;

    public int scenarioIndex;
    public Vector2 position;

    public static Files Load()
    {
        string completePath = Application.persistentDataPath + "/" + path;
        string text;
        if (File.Exists(completePath))
        {
            text = File.ReadAllText(completePath);
        }
        else
        {
            File.WriteAllText(completePath, JsonUtility.ToJson(new Files(), true));
            text = File.ReadAllText(completePath);
        }
        Files f = JsonUtility.FromJson<Files>(text);
        return f;
    }
    public void Save()
    {
        string completePath = Application.persistentDataPath + "/" + path;
        string text = JsonUtility.ToJson(this);
        if (File.Exists(path))
        {
            File.WriteAllText(completePath, text);
        }
        else
        {
            File.WriteAllText(completePath, JsonUtility.ToJson(this,true));
        }
    }
    public CaseStatus GetCaseStatus()
    {
        return status[InvestigationManager.me.currentCase];
    }
    public void SetPosition(int scenarioIndex, Vector2 position)
    {
        this.scenarioIndex = scenarioIndex;
        this.position = position;
    }
    public void SetInitialClues(List<ClueData> data, int caseIndex)
    {
        var caseData = InvestigationManager.GetCase();
        foreach(var d in data)
        {
            int i = caseData.GetClueIndexFromData(d);
            status[caseIndex].AddClue(i);
        }
    }
}
[System.Serializable]
public class Testimony
{
    public int from;
    public int clue;
    public Testimony(int clueIndex, int witnessIndex)
    {
        from = witnessIndex;
        clue = clueIndex;
    }
    public override bool Equals(object obj)
    {
        Testimony a = (Testimony)this;
        Testimony b = (Testimony)obj;
        return (a.from == b.from) && (a.clue == b.clue);
    }
}
[System.Serializable]
public class Rumor
{
    public int from;
    public int target;
    public Rumor(int fromIndex, int targetIndex)
    {
        from = fromIndex;
        target = targetIndex;
    }
    public override bool Equals(object obj)
    {
        Rumor a = (Rumor)this;
        Rumor b = (Rumor)obj;
        return (a.from == b.from) && (a.target == b.target);
    }
}
