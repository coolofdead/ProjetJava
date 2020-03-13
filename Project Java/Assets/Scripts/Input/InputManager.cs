using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum PlayerTag { Player1, Player2 }

    private VirtualInput player1, player2;

    private static InputManager singleton;

    void Awake()
    {
        singleton = this;

        player1 = new VirtualInput(KeyCode.Q, KeyCode.D, KeyCode.Z, KeyCode.S, KeyCode.T, KeyCode.A);
        player2 = new VirtualInput(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.Space, KeyCode.M);

        DontDestroyOnLoad(transform.parent);
    }

    public static VirtualInput GetVirtualInput(PlayerTag playerTag) {
        switch(playerTag) {
            case PlayerTag.Player1:
                return singleton.player1;

            case PlayerTag.Player2:
                return singleton.player2;
                
            default:
                return singleton.player1;
        }
    }
}
