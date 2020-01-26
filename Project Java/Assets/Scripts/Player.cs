using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vehicle player1;
    public Vehicle player2;

    private void Update()
    {
        transform.position += transform.forward * player1.ForwardSpeed;
    }
}
