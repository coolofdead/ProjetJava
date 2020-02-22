using UnityEngine;

public class Ywing : Vehicle
{
    public float rotateSpeed = 130f;
    public float autoRotateDivider = 2f;
    public float tiltRight;
    private float tiltLeft;
    private float curRot = 0;
    public float CurRot { get { return curRot; } }

    [SerializeField]
    private Shield shield;

    public Vector3 angularForce = new Vector3(20.0f, 20.0f, 30.0f);
    public float horizontalRotate = 15f;
    private const float forceMultiplier = 100.0f;
    private Rigidbody rbody;

    AudioSource shieldAudio;

    protected override void Start()
    {
        base.Start();

        tiltLeft = -tiltRight;

        rbody = Player.player.gameObject.AddComponent<Rigidbody>();
        rbody.angularDrag = 1f;
        rbody.drag = 1f;
        rbody.useGravity = false;

        shieldAudio = GetComponent<AudioSource>();
    }
    
    protected override void Update()
    {
        base.Update();

        if (forwardSpeed < maxForwardSpeed && curRot == 0)
        {
            forwardSpeed += acceleration * Time.deltaTime;
        }
        else if (curRot != 0)
        {
            forwardSpeed -= decelaration * Time.deltaTime;
            if (forwardSpeed < minForwardSpeed)
                forwardSpeed = minForwardSpeed;
        }
    }

    private void FixedUpdate()
    {
        Vector3 inputAxis = vInput.GetAxis();

        Player.player.transform.Rotate(-Vector3.forward * horizontalRotate * inputAxis.x * Time.deltaTime, Space.Self);
        Player.player.transform.Rotate(Vector3.right * inputAxis.y * angularForce.z * Time.deltaTime, Space.Self);

        rbody.AddRelativeForce(new Vector3(0, 0, forwardSpeed), ForceMode.Force);
    }

    public override void Act()
    {
        shield.State = !shield.State;
        if (!shieldAudio.isPlaying)
            shieldAudio.Play();
    }

    public override void Move(Vector3 dir)
    {
        Vector3 dist = Vector3.zero;

        if (dir.x == 0)
        {
            if (curRot > 0)
            {
                curRot -= 1 / (rotateSpeed / (rotateSpeed / autoRotateDivider));
                transform.Rotate(Vector3.forward, rotateSpeed / autoRotateDivider * 0.016f);
            }
            if (curRot < 0)
            {
                curRot += 1 / (rotateSpeed / (rotateSpeed / autoRotateDivider));
                transform.Rotate(Vector3.forward, -rotateSpeed / autoRotateDivider * 0.016f);
            }
        }

        if (dir.x > 0 && curRot < tiltRight || dir.x < 0 && curRot > tiltLeft)
        {
            int tiltDir = dir.x > 0 ? -1 : 1;
            curRot += dir.x > 0 ? 1 : -1;
            transform.Rotate(Vector3.forward, (rotateSpeed * tiltDir) * 0.016f);
        }
    }
}
