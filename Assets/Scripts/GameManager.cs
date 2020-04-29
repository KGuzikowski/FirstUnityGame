using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float RestartDelay = 1f;
    public float NotesRemovalDelay = 2f;
    public Text Score;
    public Text Welcome;
    public Text Explanation;
    public Text HaveFun;
    public Button Button;
    public GameObject Bg;
    public PlayerMovement movement;

    void Start()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMETUTORIAL", 1) == 1)
        { 
            //Set first time tutorial level playing to false
            PlayerPrefs.SetInt("FIRSTTIMETUTORIAL", 0);
        }
        else
        {
            movement.enabled = true;
            Score.text = "SCORE";
            Destroy(Welcome, 0);
            Destroy(Button.gameObject, 0);
            Destroy(Bg, 0);
            RemoveNotes();
        }
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart", RestartDelay);
        }
    }

    void Restart()
    {
        int number = System.Convert.ToInt32(Score.text);
        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void RemoveNotes()
    {
        Destroy(Explanation, NotesRemovalDelay);
        Destroy(HaveFun, NotesRemovalDelay);
    }

    public void CompleteLevel()
    {
        if (PlayerPrefs.GetInt("COMPLETETUTORIAL", 1) == 1)
        {
            //Set first time complete tutorial level to false
            PlayerPrefs.SetInt("COMPLETETUTORIAL", 0);
            Debug.Log("complete tutorial level");
            SceneManager.LoadScene("InfiniteLevel");
        }
        else
        {
            Debug.Log("Generate scene");
            // Generate further scene

        }
    }
}
