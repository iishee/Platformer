using UnityEngine;
using UnityEngine.UI;

public class HealthAndRespawn : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;

    private Vector3 initialPosition; // Store initial position for respawn
    public float respawnThreshold = -10f; // Set the threshold for character respawn
    public float respawnDamage = 20f; // Set the amount of damage when respawning

    public GameObject canvasObject; // Reference to the Canvas object to unhide

    private Rigidbody rb;
    private bool isGrounded;

    private bool isGameOver = false; // Flag to track game over state

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth; // Set max value for health slider
        healthSlider.value = health; // Set initial value for health slider

        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if character is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Check if character has fallen below a certain distance
        if (transform.position.y < respawnThreshold)
        {
            RespawnCharacter();
        }

        // Update health slider value
        if (health != healthSlider.value)
        {
            healthSlider.value = health;
        }

        // Check if health is zero and show game over canvas
        if (health <= 0 && !isGameOver)
        {
            if (canvasObject != null)
            {
                canvasObject.SetActive(true);
                Time.timeScale = 0f; // Freeze time
                Cursor.lockState = CursorLockMode.None; // Unlock cursor
                Cursor.visible = true; // Make cursor visible
                isGameOver = true; // Set game over flag
            }
        }
    }

    // Function to handle taking damage
   public void TakeDamage(float damage)
    {
        health -= damage;

        // Ensure health doesn't go below 0
        health = Mathf.Max(health, 0);
    }

    // Function to respawn the character
   public void RespawnCharacter()
    {
        // Reset character's position to initial position
        transform.position = initialPosition;

        // Apply damage on respawn
        TakeDamage(respawnDamage);
    }
}