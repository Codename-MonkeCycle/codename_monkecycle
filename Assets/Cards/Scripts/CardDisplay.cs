using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonkeGame;
using UnityEngine.UI;
using TMPro;


public class CardDisplay : MonoBehaviour
{
    public CardObject cardData;
    public Image cardImage;
    public TMP_Text nameText;
    public TMP_Text healText;
    public TMP_Text damageText;
    public TMP_Text shieldText;
    public TMP_Text costText;
    public TMP_Text status1Text;
    public TMP_Text status2Text;
    public TMP_Text status3Text;
    public TMP_Text status4Text;
    public TMP_Text typeText;

    void Start()
    {
        UpdateCardDisplay();   
    }

    public void UpdateCardDisplay()
    {
        cardImage = cardData.image;
        nameText.text = cardData.cardName;
        healText.text = cardData.heal.ToString();
        damageText.text = cardData.damage.ToString();
        shieldText.text = cardData.shield.ToString();
        costText.text = cardData.cost.ToString();
        status1Text.text = cardData.status1.ToString();
        status2Text.text = cardData.status2.ToString();
        status3Text.text = cardData.status3.ToString();
        status4Text.text = cardData.status4.ToString();
    }

}
