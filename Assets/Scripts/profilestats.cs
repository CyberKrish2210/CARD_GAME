using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class profilestats : MonoBehaviour
{
    public TMP_Text loggedInAsText;
    public TMP_Text gamesPlayedText;
    public TMP_Text gamesWonText;
    public TMP_Text totalMovesText;

    void OnEnable()
    {
        // Update player information when the profile panel is enabled
        UpdatePlayerInfo();
    }

    public void UpdatePlayerInfo()
    {
        // Get player information from PlayerPrefs or other data source
        string phoneNumber = PlayerPrefs.GetString("PhoneNumber", "Unknown");
        int gamesPlayed = PlayerPrefs.GetInt("GamesPlayed", 0);
        int gamesWon = PlayerPrefs.GetInt("GamesWon", 0);
        int totalMoves = PlayerPrefs.GetInt("TotalMoves", 0);

        // Update TMP Text elements with player information
        loggedInAsText.text = "Logged in as: " + phoneNumber;
        gamesPlayedText.text = "Games Played: " + gamesPlayed;
        gamesWonText.text = "Games Won: " + gamesWon;
        totalMovesText.text = "Total Moves: " + totalMoves;
    }
}
