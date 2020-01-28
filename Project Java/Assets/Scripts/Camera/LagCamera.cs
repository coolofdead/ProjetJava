using UnityEngine;

[RequireComponent(typeof(Camera))]
public class LagCamera : MonoBehaviour
{    
    public float rotateSpeed = 90.0f;

    private Transform target;
    private Vector3 startOffset;

    private void Start()
    {
        target = transform.parent;

        startOffset = transform.localPosition * 1.25f;
        transform.SetParent(null);
    }

    private void FixedUpdate()
    {
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        transform.position = target.TransformPoint(startOffset);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotateSpeed * Time.deltaTime);
    }
}
