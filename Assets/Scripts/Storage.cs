using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Storage")]
public class Storage : ScriptableObject
{
    public List<CaseData> cases;

    //Temp
    public List<ClueData> clues;
    public List<WitnessData> witnesses;
    public List<InsightData> insights;

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
        foreach(TestimonyData t in witness.testimonys)
        {
            if(t.clue == GetClueData(info.clue))
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
}
