using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CaseStatus
{
    [SerializeField] public List<int> clues = new List<int>();
    [SerializeField] public List<int> insights = new List<int>();
    [SerializeField] public List<Testimony> testimonys = new List<Testimony>();
    [SerializeField] public List<Rumor> rumors = new List<Rumor>();
    [SerializeField] public List<int> witnesses = new List<int>();

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
