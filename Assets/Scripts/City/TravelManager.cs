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
        StartCoroutine(TravelAnimation(data));
    }
    private IEnumerator TravelAnimation(PortalData data)
    {
        GlobalFlags.travel = true;
        travelTransition.DOFillAmount(0, 0);
        travelTransition.DOFillAmount(1, 0.5f);
        yield return new WaitForSeconds(0.5f);

        scenarios[currentScenario].SetActive(false);
        currentScenario = (int) data.target;
        print(currentScenario);
        scenarios[currentScenario].SetActive(true);

        FindObjectOfType<PortalSensor>().gameObject.transform.position = data.targetScenePosition;
        
        travelTransition.DOFillAmount(0, 0.5f);
        GlobalFlags.travel = false;
    }
}
