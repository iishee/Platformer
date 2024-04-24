using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float respawnYThreshold = -10f; // The y-coordinate threshold below which respawn is triggered

    private Vector3 respawnPoint; // The point where the player respawns

    void Start()
    {
        // Store the initial spawn point as the respawn point
        respawnPoint = transform.position;
    }

    void Update()
    {
        // Check if the player has fallen below the respawn threshold
        if (transform.position.y < respawnYThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Reset the player's position to the respawn point
        transform.position = respawnPoint;
        // Additional respawn logic can be added here, such as resetting health, score, etc.
    }
}