using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorialLevel : MonoBehaviour
{
    public PlayerMovement movement;
    public Text Score;
    public Text Welcome;
    public Text Explanation;
    public Text HaveFun;
    public Button Button;
    public GameObject Bg;

    // Start is called before the first frame update

    public void StartLevel()
    {
        Score.text = "SCORE";
        Destroy(Welcome, 0);
        Destroy(Explanation, 0);
        Destroy(HaveFun, 0);
        Destroy(Button.gameObject, 0);
        Destroy(Bg, 0);
        Invoke("EnableMovement", 1f);
    }

    void EnableMovement()
    {
        movement.enabled = true;
    }
}
