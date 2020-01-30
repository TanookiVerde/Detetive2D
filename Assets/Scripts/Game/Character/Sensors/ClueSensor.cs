using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueSensor : MonoBehaviour
{
    public List<Clue> collidingClues;

    public void InvestigateClue()
    {
        collidingClues[0].Investigate();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Clue clue = collision.gameObject.GetComponent<Clue>();
        if (clue != null)
        {
            if(clue.GetCase() == InvestigationManager.me.currentCase)
            {
                VerbUI.Show(VerbType.INVESTIGATE);
                collidingClues.Add(collision.gameObject.GetComponent<Clue>());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Clue clue = collision.gameObject.GetComponent<Clue>();
        if (clue != null)
        {
            if (clue.GetCase() == InvestigationManager.me.currentCase)
            {
                collidingClues.Remove(collision.gameObject.GetComponent<Clue>());
                VerbUI.Hide(VerbType.INVESTIGATE);
            }
        }
    }
}
