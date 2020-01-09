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
        if (collision.gameObject.GetComponent<Clue>() != null)
        {
            VerbUI.Show(VerbType.INVESTIGATE);
            collidingClues.Add(collision.gameObject.GetComponent<Clue>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Clue>() != null)
        {
            collidingClues.Remove(collision.gameObject.GetComponent<Clue>());
            VerbUI.Hide(VerbType.INVESTIGATE);
        }
    }
}
