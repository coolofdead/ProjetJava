using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    protected float forwardSpeed;
    public float ForwardSpeed { get { return forwardSpeed; } }
    public float maxForwardSpeed;
    public float minForwardSpeed;
    public float acceleration;
    public float decelaration;

    [SerializeField]
    protected KeyCode leftAxis, rightAxis, upAxis, downAxis, button;

    protected VirtualInput vInput;

    protected virtual void Start()
    {
        vInput = new VirtualInput(leftAxis, rightAxis, upAxis, downAxis, button);
    }

    protected virtual void Update()
    {
        if (vInput.ButtonPressed())
        {
            Act();
        }

        Move(vInput.GetInputs());
    }

    public abstract void Move(Vector3 dir);
    public abstract void Act();
}
