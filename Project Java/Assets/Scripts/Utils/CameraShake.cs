using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 0.7f;
    public float maxShake;
    public bool isEnabled = false;

    private Vector3 originalPos;
    private Transform camTransform;

    void Start()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
            originalPos = camTransform.localPosition;
        }
    }

    void Update()
    {
        if (isEnabled)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        }
    }
}