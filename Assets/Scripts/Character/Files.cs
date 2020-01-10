using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Files
{
    public const string SAVE_NAME = "game_save_15";

    [SerializeField] public List<int> clues = new List<int>();
    [SerializeField] public List<int> insights = new List<int>();
    [SerializeField] public List<Testimony> testimonys = new List<Testimony>();
    [SerializeField] public List<Rumor> rumors = new List<Rumor>();
    [SerializeField] public List<int> witnesses = new List<int>();

    public static Files Load()
    {
        var json = PlayerPrefs.GetString(SAVE_NAME);
        if (json.Length <= 1)
            return new Files();
        return JsonUtility.FromJson<Files>(json);
    }
    public void Save()
    {
        var json = JsonUtility.ToJson(this);
        Debug.Log("SAVE::" + json);
        PlayerPrefs.SetString(SAVE_NAME, json);
    }
    public bool AddTestimony(Testimony testimony)
    {
        if (!testimonys.Contains(testimony))
        {
            testimonys.Add(testimony);
            return true;
        }
        return false;
    }
    public bool AddWitness(int witness)
    {
        if (!witnesses.Contains(witness))
        {
            witnesses.Add(witness);
            return true;
        }
        return false;
    }
    public bool AddClue(int clue)
    {
        if (!clues.Contains(clue))
        {
            clues.Add(clue);
            return true;
        }
        return false;
    }
    public bool AddRumor(Rumor rumor)
    {
        if (!rumors.Contains(rumor))
        {
            rumors.Add(rumor);
            return true;
        }
        return false;
    }
    public bool AddInsight(int insight)
    {
        if (!insights.Contains(insight))
        {
            insights.Add(insight);
            return true;
        }
        return false;
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
