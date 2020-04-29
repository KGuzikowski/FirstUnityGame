using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 1000f;
    public float backForce = 400f;
    public float sidesForce = 500f;
    public float maxSpeed = 400f;

    // Update is called once per frame
    void FixedUpdate()
    {
        // add forward force
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        else
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if(Input.GetKey("right")) {
            rb.AddForce(sidesForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("left")) {
            rb.AddForce(-sidesForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -backForce * Time.deltaTime);
        }

        if(rb.position.y < 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
