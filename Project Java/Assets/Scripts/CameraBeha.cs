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
    private Transform anchorTransform;
    public Vector3 recoil;

    private void Start()
    {
        shake = GetComponent<CameraShake>();
        anchorTransform = transform.parent;
    }

    private void Update()
    {
        //transform.position = Vector3.Lerp(anchorTransform.position + recoil, anchorTransform.position + recoil - transform.forward * recoilFactor, player.player1.ForwardSpeed / player.player1.maxForwardSpeed);

        //shake.isEnabled = player.player1.ForwardSpeed / player.player1.maxForwardSpeed > shakeSpeedRatio;
    }
}
