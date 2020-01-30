using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class TravelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> scenarios = new List<GameObject>();
    [SerializeField] private Image travelTransition;

    private int currentScenario = 0;

    public void Travel(PortalData data)
    {
        StartCoroutine(TravelAnimation((int) data.target, data.targetScenePosition));
    }
    public static void Travel(TaxiPlaceData data)
    {
        var me = FindObjectOfType<TravelManager>();
        me.StartCoroutine(me.TravelAnimation(data.scenarioIndex, data.position));
    }
    private IEnumerator TravelAnimation(int targetScenario, Vector2 position)
    {
        GlobalFlags.travel = true;
        travelTransition.DOFillAmount(0, 0);
        travelTransition.DOFillAmount(1, 0.5f);
        yield return new WaitForSeconds(0.5f);

        scenarios[currentScenario].SetActive(false);
        currentScenario = targetScenario;
        scenarios[currentScenario].SetActive(true);

        FindObjectOfType<PortalSensor>().gameObject.transform.position = position;
        
        travelTransition.DOFillAmount(0, 0.5f);
        GlobalFlags.travel = false;

        Files files = Files.Load();
        files.SetPosition(targetScenario, position);
        files.Save();
    }
    public static int GetCurrentScenario()
    {
        return FindObjectOfType<TravelManager>().currentScenario;
    }
}
