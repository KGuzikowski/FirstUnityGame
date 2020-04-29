using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
