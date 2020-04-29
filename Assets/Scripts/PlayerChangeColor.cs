using System.Collections;
using UnityEngine;

public class PlayerChangeColor : MonoBehaviour
{
    public Material[] Materials = new Material[5];
    private bool isCoroutineExecuting = false;
    private Material PreviousMaterial;

    void ChangeColor()
    {
        int i = Random.Range(0, 5);
        PreviousMaterial = GetComponent<Renderer>().material;
        GetComponent<Renderer>().material = Materials[i];
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        GameObject[] obstaclesRotated = GameObject.FindGameObjectsWithTag("ObstacleRotated");

        foreach(GameObject obstacle in obstacles)
        {
            // undo the changes form last time method was fired
            if(obstacle.GetComponent<Renderer>().material.name == PreviousMaterial.name)
            {
                obstacle.GetComponent<Rigidbody>().mass = 3f;
                obstacle.tag = "Obstacle";
            }

            if (GetComponent<Renderer>().material.name == obstacle.GetComponent<Renderer>().material.name)
            {
                obstacle.GetComponent<Rigidbody>().mass = 0f;
                obstacle.tag = "Friend";
            }
        }

        foreach (GameObject ball in balls)
        {
            // undo the changes form last time method was fired
            if (ball.GetComponent<Renderer>().material.name == PreviousMaterial.name)
            {
                ball.GetComponent<Rigidbody>().mass = 2f;
                ball.tag = "Ball";
            }

            if (GetComponent<Renderer>().material.name == ball.GetComponent<Renderer>().material.name)
            {
                ball.GetComponent<Rigidbody>().mass = 0f;
                ball.tag = "Friend";
            }
        }

        foreach (GameObject obstacle in obstaclesRotated)
        {
            // undo the changes form last time method was fired
            if (obstacle.GetComponent<Renderer>().material.name == PreviousMaterial.name)
            {
                obstacle.GetComponent<Rigidbody>().isKinematic = false;
                obstacle.tag = "ObstacleRotated";
            }
            //Debug.Log(obstacle.GetComponent<Renderer>().material.name);
            if (GetComponent<Renderer>().material.name == obstacle.GetComponent<Renderer>().material.name)
            {
                obstacle.GetComponent<Rigidbody>().isKinematic = true;
                obstacle.tag = "Friend";
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        ChangeColor();

        isCoroutineExecuting = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Random.Range(2, 5);
        StartCoroutine(ExecuteAfterTime(time));
    }
}
