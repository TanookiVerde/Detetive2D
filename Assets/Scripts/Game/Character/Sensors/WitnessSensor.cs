using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitnessSensor : MonoBehaviour
{
    public List<Witness> collidingWitness = new List<Witness>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var witness = collision.GetComponent<Witness>();
        if (witness != null && InvestigationManager.me.currentCase == witness.GetCase())
        {
            VerbUI.Show(VerbType.ASK);
            collidingWitness.Add(witness);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var witness = collision.GetComponent<Witness>();
        if (witness != null && InvestigationManager.me.currentCase == witness.GetCase())
        {
            VerbUI.Hide(VerbType.ASK);
            collidingWitness.Remove(witness);
        }
    }
    public void AskWitness(ClueData clue)
    {
        collidingWitness[0].Ask(clue);
    }
    public void AskWitness(WitnessData witness)
    {
        collidingWitness[0].Ask(witness);
    }
    public void IntroduceToWitness()
    {
        collidingWitness[0].Introduce();
    }
}
