using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonkeGame;
using System;

public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform handTransform; //root of hand positoin
    public float fanSpread = -14f;
    public List<GameObject> cardsInHand = new List<GameObject>();
    public float horiSpace = -120f;
    public float verticalSpace = 102f;
    public int maxHandSize = 9;

    void Start()
    {

    }

    public void AddCardToHand(CardObject cardData)
    {
        if (cardsInHand.Count == maxHandSize)
        {
            return;
        }
        else { 
        //Instantiate cards
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        //Set instantiated cards data
        newCard.GetComponent<CardDisplay>().cardData = cardData;

        UpdateHandVisuals();
        }
    }



    public void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;

        if (cardCount == 1)
        {
            cardsInHand[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            cardsInHand[0].transform.localPosition = new Vector3(0f, 0f, 0f);
            return;

        }

        for (int i = 0; i < cardCount; i++)
        {
            float rotationAngle = (fanSpread * (i - (cardCount - 1) /2f));
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f , rotationAngle);

            float horizontalOffset = (horiSpace * (i - (cardCount - 1) / 2f));

            float normalizedPosition = (2f * i /(cardCount - 1) - 1f); //normalized card pos 1 and -1
            float verticalOffset = verticalSpace * (1 - normalizedPosition * normalizedPosition);

            //set card position
            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }

    void Update()
    {
        //UpdateHandVisuals();
    }
}
