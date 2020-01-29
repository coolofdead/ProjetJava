using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraShake))]
public class CameraBeha : MonoBehaviour
{
    public Player player;
    private CameraShake shake;

    public float recoilFactor;
    [Range(0, 1)]
    public float shakeSpeedRatio;

    public Transform anchor;
    public float minDist = 55f;
    public float yOffset = 20f;

    private void Start()
    {
        shake = GetComponent<CameraShake>();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(
            anchor.position + -transform.forward * minDist,
            anchor.position + -transform.forward * minDist + -transform.forward * recoilFactor,
            player.player1.ForwardSpeed / player.player1.maxForwardSpeed);

        transform.position += new Vector3(0, yOffset, 0);

        shake.isEnabled = player.player1.ForwardSpeed / player.player1.maxForwardSpeed > shakeSpeedRatio;
        shake.shakeAmount = Mathf.Lerp(shake.shakeAmount, shake.maxShake, player.player1.ForwardSpeed / player.player1.maxForwardSpeed);
    }
}
