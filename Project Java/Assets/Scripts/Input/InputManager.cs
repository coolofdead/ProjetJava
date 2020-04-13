using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public enum PlayerTag { Player1, Player2 }

    private static VirtualInput player1 = new VirtualInput(KeyCode.Q, KeyCode.D, KeyCode.Z, KeyCode.S, KeyCode.T, KeyCode.A);
    private static VirtualInput player2 = new VirtualInput(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.Space, KeyCode.M);

    public static VirtualInput GetVirtualInput(PlayerTag playerTag) {
        switch(playerTag) {
            case PlayerTag.Player1:
                return player1;

            case PlayerTag.Player2:
                return player2;
                
            default:
                return null;
        }
    }
}
