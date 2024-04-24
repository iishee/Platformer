using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public Button restartButton;

    private void Start()
    {
        // Add a listener to the button click event
        restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        // Unfreeze time
        Time.timeScale = 1f;

        // Restart the game logic here
        Debug.Log("Game restarted!");

        // For example, you can reload the current scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}