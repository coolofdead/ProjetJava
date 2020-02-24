using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalIndicatorUI : MonoBehaviour
{
    private float maxDistance;
    public float minScale, maxScale;

    private void Start()
    {
        maxDistance = Vector3.Distance(transform.position, Player.player.transform.position);
    }

    void Update()
    {
        float t = Vector3.Distance(transform.position, Player.player.transform.position) / maxDistance;
        transform.localScale = Vector3.one * Mathf.Lerp(minScale, maxScale, t);
    }
}
