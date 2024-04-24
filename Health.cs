using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    private float health;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth; // Set max value for health slider
        healthSlider.value = health; // Set initial value for health slider
    }

    // Update is called once per frame
    void Update()
    {
        if (health != healthSlider.value)
        {
            healthSlider.value = health;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    // Function to handle taking damage
    void TakeDamage(float damage)
    {
        health -= damage;

        // Ensure health doesn't go below 0
        if (health < 0)
        {
            health = 0;
        }
    }
}