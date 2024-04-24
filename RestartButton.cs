using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public Button restartButton; // Reference to the restart button

    void Start()
    {
        // Add a listener for the restart button's click event
        restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        // Unfreeze time
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}