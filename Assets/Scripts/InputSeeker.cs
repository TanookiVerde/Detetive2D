using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSeeker : MonoBehaviour
{
    public static List<InputSeeker> seekers = new List<InputSeeker>();
    public bool interactable;

    public virtual void OnBack() {}
    public virtual void OnLeave() {}
    public static void Enter(InputSeeker obj)
    {
        if (seekers.Count > 0)
        {
            seekers[seekers.Count - 1].StartCoroutine(seekers[seekers.Count - 1].WaitFrameToSet(false));
            seekers[seekers.Count - 1].OnLeave();
        }
        seekers.Add(obj);
        obj.StartCoroutine(obj.WaitFrameToSet(true));
    }
    public static void Exit()
    {
        seekers[seekers.Count - 1].StartCoroutine(seekers[seekers.Count - 1].WaitFrameToSet(false));
        seekers.Remove(seekers[seekers.Count - 1]);
        seekers[seekers.Count - 1].StartCoroutine(seekers[seekers.Count - 1].WaitFrameToSet(true));
        seekers[seekers.Count - 1].OnBack();
    }
    private IEnumerator WaitFrameToSet(bool active)
    {
        //Função feia
        yield return null;
        interactable = active;
    }
    public static void PrintHierachy()
    {
        var s = "";
        for(int i = 0; i < seekers.Count; i++)
        {
            s += "->" + seekers[i].name + "(" + seekers[i].interactable + ")";
        }
        Debug.Log(s);
    }
}
