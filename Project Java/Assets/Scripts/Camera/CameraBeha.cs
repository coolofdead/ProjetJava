using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeha : MonoBehaviour
{
    public Transform anchor;

    public float smoothSpeed = 0.125f;
    public float smoothRotate = 0.125f;
    public float horizontalSmoothRotate = 0.7f;
    public float verticalSmoothRotate = 0.7f;
    public float forwardMultiplicator = 5f;
    public Vector3 rotationOffset;

    private void OnEnable()
    {
        Destroy(GetComponent<Animator>());
        EnablePlayer();
    }

    private void Start()
    {
        transform.SetParent(transform.parent.parent);
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = anchor.position + anchor.forward * forwardMultiplicator + transform.up * verticalSmoothRotate;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        var q = Quaternion.Euler(transform.eulerAngles + rotationOffset);
        transform.rotation = Quaternion.Lerp(q, anchor.rotation, smoothRotate);
    }

    public void EnablePlayer()
    {
        Player.player.player1.enabled = true;
        Player.player.player2.enabled = true;
    }
}
