using UnityEngine;

public class Ywing : Vehicle, IDamageable
{
    public float rotateSpeed = 130f;
    public float tiltRight;
    public float tiltLeft;
    private float curRot = 0;
    private int life = 3;

    [SerializeField]
    private Shield shield;
    public GameObject[] fireImpacts;

    [SerializeField]
    private Player player;

    public Vector3 angularForce = new Vector3(20.0f, 20.0f, 30.0f);
    private const float forceMultiplier = 100.0f;
    private Rigidbody rbody;

    void Awake()
    {
        rbody = player.gameObject.AddComponent<Rigidbody>();
        rbody.angularDrag = 1.5f;
        rbody.drag = 1f;
        rbody.useGravity = false;
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
        Vector3 linearInput = new Vector3(inputAxis.y, inputAxis.x, -inputAxis.x * 0.5f);

        rbody.AddRelativeForce(new Vector3(0, 0, forwardSpeed), ForceMode.Force);
        rbody.AddRelativeTorque(Vector3.Scale(angularForce, linearInput) * forceMultiplier, ForceMode.Force);
    }

    public override void Act()
    {
        shield.State = !shield.State;
    }

    public override void Move(Vector3 dir)
    {
        Vector3 dist = Vector3.zero;

        if (dir.x == 0)
        {
            if (curRot > 0)
            {
                curRot--;
                transform.Rotate(Vector3.forward, rotateSpeed * 0.016f);
            }
            if (curRot < 0)
            {
                curRot++;
                transform.Rotate(Vector3.forward, -rotateSpeed * 0.016f);
            }
        }

        if (dir.x > 0 && curRot < tiltRight || dir.x < 0 && curRot > tiltLeft)
        {
            int tiltDir = dir.x > 0 ? -1 : 1;
            curRot += dir.x > 0 ? 1 : -1;
            transform.Rotate(Vector3.forward, (rotateSpeed * tiltDir) * 0.016f);
        }
    }

    public void TakeDamage(int amount, bool instantKill = false)
    {
        life -= instantKill ? life : amount;
        for (int i = 0; i < 3 - life; i++)
            fireImpacts[i].SetActive(true);

        if (life <= 0)
        {
            Debug.Log("Player die");
        }
    }
}
