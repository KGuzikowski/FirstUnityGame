using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Obstacle" || collision.collider.tag == "ObstacleRotated")
        {
            // Debug.Log(GameObject.Find(collision.collider.name).GetComponent<Renderer>().material.name);
            // Debug.Log(GetComponent<Renderer>().material.name);
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        string ObstacleMaterial = GameObject.Find(collision.collider.name).GetComponent<Renderer>().material.name;
        string material = GetComponent<Renderer>().material.name;

        if (collision.collider.tag == "AnimatedObstacle" && material == ObstacleMaterial)
        {
            Rigidbody obstacleRb = GameObject.Find(collision.collider.name).GetComponent<Rigidbody>();
            obstacleRb.isKinematic = false;
            obstacleRb.mass = 0;
        } else if(collision.collider.tag == "AnimatedObstacle" && material != ObstacleMaterial)
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
