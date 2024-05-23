using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] cardPrefabs; // Array of card prefabs
    public Transform[] handPositions; // Array of positions in the hand area
    private List<GameObject> handCards = new List<GameObject>(); // List to store cards in the player's hand
    public int maxHandSize = 3; // Maximum number of cards allowed in the hand

    private HandValueCalculator handValueCalculator; // Reference to the HandValueCalculator

    private void Start()
    {
        handValueCalculator = FindObjectOfType<HandValueCalculator>(); // Find the HandValueCalculator in the scene
    }

    // Pick a card and replace a random card in the hand
    public void PickACardAndReplace()
    {
        if (handCards.Count < maxHandSize)
        {
            // If hand is not full, add a new card
            SpawnRandomCard();
        }
        else
        {
            // If hand is full, replace a random card
            ReplaceRandomCard();
        }
        int movesPlayed = PlayerPrefs.GetInt("TotalMoves", 0);
        movesPlayed++;
        PlayerPrefs.SetInt("TotalMoves", movesPlayed);

        handValueCalculator.UpdateHandValueText();
    }

    // Discard a random card from the hand
    public void DiscardRandomCard()
    {
        if (handCards.Count > 0)
        {
            int randomIndex = Random.Range(0, handCards.Count);
            GameObject cardToRemove = handCards[randomIndex];
            handCards.Remove(cardToRemove);
            Destroy(cardToRemove);

            int movesPlayed = PlayerPrefs.GetInt("TotalMoves", 0);
            movesPlayed++;
            PlayerPrefs.SetInt("TotalMoves", movesPlayed);

            handValueCalculator.UpdateHandValueText();
        }
        else
        {
            Debug.LogWarning("Hand is empty. Cannot discard.");
        }
    }

    // Spawn a random card into the hand area
    // Spawn a random card into the hand area
    // Spawn a random card into the hand area
    private void SpawnRandomCard()
    {
        // Get a random card prefab from the array
        GameObject randomCardPrefab = cardPrefabs[Random.Range(0, cardPrefabs.Length)];

        // Choose a random position in the hand area
        Transform randomPosition = GetAvailableHandPosition();

        // Instantiate the random card at the chosen position
        GameObject newCard = Instantiate(randomCardPrefab, randomPosition.position, Quaternion.identity);

        // Set the parent to the hand area
        newCard.transform.SetParent(randomPosition);

        // Set the scale and position of the new card to match the existing cards in the hand
        Vector3 cardScale = new Vector3(1f, 1f, 1f); // Set the scale to match the desired size
        Vector3 cardPosition = Vector3.zero; // Set the position to match the desired position

        // Apply scale and position to the new card
        newCard.transform.localScale = cardScale;
        newCard.transform.localPosition = cardPosition;

        handCards.Add(newCard); // Add the card to the player's hand
    }

    // Replace a random card in the hand with a new random card
    private void ReplaceRandomCard()
    {
        if (handCards.Count > 0)
        {
            int randomIndex = Random.Range(0, handCards.Count);
            GameObject cardToReplace = handCards[randomIndex];
            handCards.Remove(cardToReplace);
            Destroy(cardToReplace);

            // Spawn a new random card in the same position
            SpawnRandomCard();
        }
        else
        {
            Debug.LogWarning("Hand is empty. Cannot replace.");
        }
    }

    // Get an available position in the hand area
    private Transform GetAvailableHandPosition()
    {
        foreach (Transform position in handPositions)
        {
            if (position.childCount == 0)
            {
                return position;
            }
        }
        return null;
    }
    public List<GameObject> GetHandCards()
    {
        return handCards;
    }
}
