using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeha : MonoBehaviour
{
    public float recoilFactor;

    public Transform anchor;
    public float minDist = 55f;
    public float yOffset = 20f;

    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -30);

    private void Update()
    {
        return;
        transform.position = Vector3.Lerp(
            anchor.position + -transform.forward * minDist,
            anchor.position + -transform.forward * minDist + -transform.forward * recoilFactor,
             Player.player.player1.ForwardSpeed / Player.player.player1.maxForwardSpeed);

        transform.position += new Vector3(0, yOffset, 0);
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = anchor.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(anchor);
    }

    public void EnablePlayer()
    {
        Player.player.player1.enabled = true;
        Player.player.player2.enabled = true;
    }
}
