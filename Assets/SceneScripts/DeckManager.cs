using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonkeGame;

public class DeckManager : MonoBehaviour
{

    public List<CardObject> allCards = new List<CardObject>();
    public int startingHand = 4;
    private int currentIndex = 0;
    private void Start()
    {
        //Load all card assets from the Resources folder
        CardObject[] cards = Resources.LoadAll<CardObject>("Cards");

        // Add loaded cards into the allcards list
        allCards.AddRange(cards);
        HandManager handMan = FindObjectOfType<HandManager>();
        for (int i = 0; i < startingHand; i++)
        {
            DrawCard(handMan);
        }
    }

    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0)
        return;

        CardObject nextCard = allCards[currentIndex];
        handManager.AddCardToHand(nextCard);
        currentIndex = (currentIndex + 1) % allCards.Count;

    }

}
