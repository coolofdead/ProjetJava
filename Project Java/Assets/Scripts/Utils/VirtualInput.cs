using UnityEngine;

public class VirtualInput
{
    private KeyCode leftAxis, rightAxis, upAxis, downAxis, button;

    public VirtualInput(KeyCode leftAxis, KeyCode rightAxis, KeyCode upAxis, KeyCode downAxis, KeyCode button)
    {
        this.leftAxis = leftAxis;
        this.rightAxis = rightAxis;
        this.upAxis = upAxis;
        this.downAxis = downAxis;
        this.button = button;
    }

    public Vector3 GetInputs()
    {
        Vector3 dir = Vector3.zero;

        dir.x += Input.GetKey(rightAxis) ? 1 : 0;
        dir.x += Input.GetKey(leftAxis) ? -1 : 0;
        dir.y += Input.GetKey(upAxis) ? 1 : 0;
        dir.y += Input.GetKey(downAxis) ? -1 : 0;

        return dir;
    }

    public bool ButtonPressed()
    {
        return Input.GetKeyDown(button);
    }
}
