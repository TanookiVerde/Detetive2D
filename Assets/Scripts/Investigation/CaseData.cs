using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/Case")]
public class CaseData : ScriptableObject
{
    [Header("Basic Information")]
    public string title;
    public string description;
    public string location;
    public Sprite image;

    [Header("Data")]
    public List<ClueData> initialClues;
    public List<WitnessData> witnesses;
    public List<InsightData> insights;
    public List<ClueData> clues;

    [Header("Report")]
    public ReportData report;

    public ClueData GetClueData(int index)
    {
        return clues[index];
    }
    public WitnessData GetWitnessData(int index)
    {
        return witnesses[index];
    }
    public InsightData GetInsightData(int index)
    {
        return insights[index];
    }
    public TestimonyData GetTestimonyData(Testimony info)
    {
        WitnessData witness = GetWitnessData(info.from);
        foreach (TestimonyData t in witness.testimonys)
        {
            if (t.clue == GetClueData(info.clue))
            {
                return t;
            }
        }
        return null;
    }
    public RumorData GetRumorData(Rumor info)
    {
        WitnessData witness = GetWitnessData(info.from);
        Debug.Log("W:" + witness.witnessName);
        foreach (RumorData r in witness.rumors)
        {
            if (r.target == GetWitnessData(info.target))
            {
                return r;
            }
        }
        return null;
    }
    public Testimony GetTestimonyFromData(TestimonyData data)
    {
        return new Testimony(GetClueIndexFromData(data.clue), GetWitnessIndexFromData(data.witness));
    }
    public Rumor GetRumorFromData(RumorData data)
    {
        return new Rumor(GetWitnessIndexFromData(data.from), GetWitnessIndexFromData(data.target));
    }
    public int GetClueIndexFromData(ClueData data)
    {
        return clues.IndexOf(data);
    }
    public int GetInsightIndexFromData(InsightData data)
    {
        return insights.IndexOf(data);
    }
    public int GetWitnessIndexFromData(WitnessData data)
    {
        return witnesses.IndexOf(data);
    }
    public List<ClueData> ListAllCluesIn(Files files)
    {
        var cluesList = new List<ClueData>();
        foreach(var c in files.clues)
        {
            cluesList.Add(clues[c]);
        }
        return cluesList;
    }
}
