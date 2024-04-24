using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Slider HealthSlider;
    public int damage = 10;
    public HealthAndRespawn HR;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call TakeDamage method from HealthAndRespawn script to deduct health
            HR.TakeDamage(damage);
        }
    }
}