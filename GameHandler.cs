using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public TextMeshProUGUI GemText;
    public int Gems;

    void Start()
    {
        Gems = PlayerPrefs.GetInt("Gems", 0);
        UpdateGemText();
    }

    void Update()
    {
        UpdateGemText();

        // Check if exiting play mode and reset Gems to 0
        if (!Application.isPlaying)
        {
            ResetGems();
        }
    }

    void UpdateGemText()
    {
        GemText.text = "Gems: " + Gems;
    }

    public void SaveGems()
    {
        PlayerPrefs.SetInt("Gems", Gems);
        PlayerPrefs.Save();
    }

    // Method to reset Gems to 0
    void ResetGems()
    {
        Gems = 0;
        UpdateGemText();
    }
}