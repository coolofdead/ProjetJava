using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vehicle player1;
    public Vehicle player2;

    public static Player player;

    private void Awake()
    {
        player = this;
    }
}
