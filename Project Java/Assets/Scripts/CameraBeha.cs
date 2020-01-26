using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraShake))]
public class CameraBeha : MonoBehaviour
{
    public Player player;
    private CameraShake shake;
    private Vector3 defaultPos;

    public float recoilFactor;
    [Range(0, 1)]
    public float shakeSpeedRatio;

    private void Start()
    {
        shake = GetComponent<CameraShake>();
        defaultPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(defaultPos, defaultPos - transform.forward * recoilFactor, player.player1.ForwardSpeed / player.player1.maxForwardSpeed);

        shake.isEnabled = player.player1.ForwardSpeed / player.player1.maxForwardSpeed > shakeSpeedRatio;
    }
}
