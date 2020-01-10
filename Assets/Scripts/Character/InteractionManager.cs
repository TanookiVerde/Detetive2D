using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Storage storage;

    public static Selection selection = new Selection();

    public WitnessSensor witnessSensor;
    public DialogSensor dialogSensor;
    public ClueSensor clueSensor;
    public PortalSensor portalSensor;
    public InvestigationSpotSensor spotSensor;

    private void Update()
    {
        if (GlobalFlags.dialog || GlobalFlags.filesMenuOpened || GlobalFlags.onInvestigationSpot)
            return;
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(clueSensor.collidingClues.Count > 0)
            {
                clueSensor.InvestigateClue();
            }
            else if (witnessSensor.collidingWitness.Count > 0)
            {
                if (selection.type == SelectionType.CLUE)
                    witnessSensor.AskWitness(storage.clues[selection.clue]);
                else if (selection.type == SelectionType.WITNESS)
                    witnessSensor.AskWitness(storage.witnesses[selection.witness]);
                else if (selection.type == SelectionType.NONE)
                {
                    witnessSensor.IntroduceToWitness();
                }
            }else if(portalSensor.collidingPortal.Count > 0)
            {
                portalSensor.EnterPortal();
            }
            else if (spotSensor.collidingSpots.Count > 0)
            {
                spotSensor.OpenInvestigationSpot();
            }
        }
    }
}
[System.Serializable]
public class Selection
{
    public SelectionType type = SelectionType.NONE;
    public int clue = -1;
    public int witness = -1;

    public Selection()
    {
        type = SelectionType.NONE;
        clue = -1;
        witness = -1;
    }
    public void ChangeType()
    {
        Files files = Files.Load();
        if (type == SelectionType.NONE)
        {
            if (files.clues.Count > 0)
            {
                type = SelectionType.CLUE;
                clue = files.clues[0];
            }
            else if (files.witnesses.Count > 0)
            {
                type = SelectionType.WITNESS;
                witness = files.witnesses[0];
            }
        }
        else if (type == SelectionType.CLUE)
        {
            if (files.witnesses.Count > 0) 
            { 
                type = SelectionType.WITNESS;
                witness = files.witnesses[0];
            }
            else
            {
                type = SelectionType.NONE;
            }
        }
        else if (type == SelectionType.WITNESS)
        {
            type = SelectionType.NONE;
        }
    }
    public void Shift(int direction)
    {
        Files f = Files.Load();
        if(type == SelectionType.CLUE)
        {
            int index = f.clues.IndexOf(clue);
            index = Mathf.Clamp(index + direction, 0, f.clues.Count-1);
            clue = f.clues[index];
        }else if(type == SelectionType.WITNESS)
        {
            int index = f.witnesses.IndexOf(witness);
            index = Mathf.Clamp(index + direction, 0, f.witnesses.Count-1);
            witness = f.witnesses[index];
        }
    }
    public void Select(SelectionType type, int index)
    {
        this.type = type;
        if (type == SelectionType.CLUE)
            clue = index;
        else
            witness = index;
    }
}
public enum SelectionType
{
    NONE, CLUE, WITNESS
}
