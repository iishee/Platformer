using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Save Gems value before transitioning to the next scene

            FindObjectOfType<GameHandler>().SaveGems();
            // Load the next scene
            SceneManager.LoadScene(sceneName);
        }
    }
}