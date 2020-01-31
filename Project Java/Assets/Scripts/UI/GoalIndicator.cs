using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalIndicator : MonoBehaviour
{
    public Transform reference;
    public Transform besideTo;

    public Image image;
    [SerializeField]
    private float radius;

    void Update()
    {
        image.enabled = reference != null;

        if (reference == null)
            return;

        var dir = reference.position - besideTo.position;
        image.transform.localPosition = new Vector3(dir.normalized.x, dir.normalized.z, 0) * radius;
    }
}
