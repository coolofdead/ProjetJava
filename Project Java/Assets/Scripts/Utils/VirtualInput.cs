using UnityEngine;

public class VirtualInput
{
    private KeyCode leftAxis, rightAxis, upAxis, downAxis, button1, button2;
    private int playerId;
    public int PlayerId { get { return playerId; } }

    public VirtualInput(KeyCode leftAxis, KeyCode rightAxis, KeyCode upAxis, KeyCode downAxis, KeyCode button1, KeyCode button2, int playerId = 1)
    {
        this.leftAxis = leftAxis;
        this.rightAxis = rightAxis;
        this.upAxis = upAxis;
        this.downAxis = downAxis;
        this.button1 = button1;
        this.button2 = button2;
        this.playerId = playerId;
    }

    public Vector3 GetAxis()
    {
        Vector3 dir = Vector3.zero;

        dir.x += Input.GetKey(rightAxis) ? 1 : 0;
        dir.x += Input.GetKey(leftAxis) ? -1 : 0;
        dir.y += Input.GetKey(upAxis) ? 1 : 0;
        dir.y += Input.GetKey(downAxis) ? -1 : 0;

        return dir;
    }

    public bool FirstButtonPressed()
    {
        return Input.GetKeyDown(button1);
    }

    public bool SecondButtonPressed()
    {
        return Input.GetKeyDown(button2);
    }
}
