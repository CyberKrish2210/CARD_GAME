using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandValueCalculator : MonoBehaviour
{
    public CardManager cardManager;
    public TMP_Text handValueText; // Reference to the UI Text element
    public GameObject winningPanel; // Reference to the winning panel GameObject
    public GameObject Handarea;

    // Calculate the total value of the cards in the hand
    public int CalculateTotalValue()
    {
        int totalValue = 0;
        List<GameObject> handCards = cardManager.GetHandCards();

        foreach (GameObject card in handCards)
        {
            carddata cardComponent = card.GetComponent<carddata>();
            if (cardComponent != null)
            {
                totalValue += cardComponent.cardValue;
            }
        }

        return totalValue;
    }

    // Update the UI Text with the current hand value
    public void UpdateHandValueText()
    {
        int totalValue = CalculateTotalValue();
        handValueText.text = "Total Value: " + totalValue;
        Debug.Log("Total value of cards in hand: " + totalValue);

        if (totalValue == 26)
        {
            // Increment the number of games won
            int gamesWon = PlayerPrefs.GetInt("GamesWon", 0);
            gamesWon++;
            PlayerPrefs.SetInt("GamesWon", gamesWon);
            Debug.Log("Player won a game! Total games won: " + gamesWon);

            // Disable the hand area to make the cards invisible
            Handarea.SetActive(false);

            // Show the winning panel
            winningPanel.SetActive(true);
        }
        else
        {
            // Hide the winning panel if the total value is not 26
            winningPanel.SetActive(false);
            // Enable the hand area if the total value is not 26
            Handarea.SetActive(true);
        }

    }
}
