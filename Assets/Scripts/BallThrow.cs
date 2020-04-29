using UnityEngine;

public class BallThrow : MonoBehaviour
{
    Transform PlayerTransform;
    public Transform Transform;
    public Rigidbody rb;
    public float BallOffset = 5;
    public float throwForceX = 400f;
    public float throwForceZ = 250f;
    public bool fromRight;
    bool hasBeenThrown = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Abs(Transform.position.z - PlayerTransform.position.z);
        if (offset <= BallOffset)
        {
            if (!hasBeenThrown)
            {
                rb.useGravity = true;
                if(fromRight)
                {
                    rb.AddForce(-throwForceX * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                else
                {
                    rb.AddForce(throwForceX * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                rb.AddForce(0, 0, -throwForceZ * Time.deltaTime, ForceMode.VelocityChange);
                hasBeenThrown = true;
            }
        }
    }
}
