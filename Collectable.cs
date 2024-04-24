using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Add this line to use Unity's UI system

public class Collectable : MonoBehaviour
{
    public AudioClip collectSound; // Drag and drop the sound clip in the inspector
    public TMP_Text countText; // Reference to the UI Text component for displaying count
    public GameHandler GH;
    private AudioSource audioSource;
    private int count = 0; // Counter for collectibles

    void Start()
    {
        UpdateCountText(); // Update the count text when the game starts
        GH = GameObject.Find("Canvas").GetComponent<GameHandler>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("You got a Diamond!");
            // Increment count
            count++;
            // Update the count text
            UpdateCountText();
            // Play the collect sound
            PlayCollectSound();
        }
    }

    void PlayCollectSound()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource component is not attached, then add it dynamically
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Add the audio clip to the AudioSource and play it
        audioSource.clip = collectSound;
        audioSource.Play();

        // Start a coroutine to wait for the sound to finish playing before destroying the object
        StartCoroutine(DestroyAfterSound());
    }

    IEnumerator DestroyAfterSound()
    {
        // Wait for the duration of the sound clip
        yield return new WaitForSeconds(collectSound.length);
        GH.Gems++;
        // Destroy the collectible object after the sound has finished playing
        Destroy(gameObject);
    }

    void UpdateCountText()
    {
        // Update the UI Text component with the current count
        countText.text = "Collected: " + count.ToString();
    }
}