using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    // Method to load a scene by name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        int gamesPlayed = PlayerPrefs.GetInt("GamesPlayed", 0); // Get the current value of GamesPlayed, defaulting to 0 if not set
        gamesPlayed++; // Increment the value
        PlayerPrefs.SetInt("GamesPlayed", gamesPlayed); // Store the updated value back in PlayerPrefs
    }

    // Method to quit the application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    // Method to log out
    public void LogOut()
    {
        PlayerPrefs.DeleteAll(); // Delete all player preferences
        SceneManager.LoadScene("Login"); // Load the login scene
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Dashboard")
        {
            // Assuming the volume slider is in the dashboard scene and tagged as "VolumeSlider"
            GameObject sliderObject = GameObject.FindWithTag("VolumeSlider");
            if (sliderObject != null)
            {
                Slider volumeSlider = sliderObject.GetComponent<Slider>();
                if (volumeSlider != null)
                {
                    soundmanager.Instance.SetVolumeSlider(volumeSlider);
                }
            }
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
