using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private Transform[] positions = new Transform[2];
    [SerializeField] private BoxCollider2D ceiling;

    public Vector2 GetNearPosition(Transform player)
    {
        float d1 = (positions[0].position - player.position).magnitude;
        float d2 = (positions[1].position - player.position).magnitude;
        return d1 < d2 ? positions[0].position : positions[1].position;
    }
    public Vector2[] GetBounds()
    {
        Vector2[] pos =  new Vector2[2];
        pos[0] = positions[0].position;
        pos[1] = positions[1].position;
        return pos;
    }
    public void SetCeilingActive(bool value)
    {
        ceiling.gameObject.SetActive(value);
    }
}
