using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonkeGame;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;


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
    private Color[] rarityColors =
    {
        Color.black,//common
        new Color(0.7490197f, 0.2555479f, 0.149804f,1), //rare
        Color.magenta//mythic
    };
    

    void Start()
    {
        UpdateCardDisplay();   
    }

    public void UpdateCardDisplay()
    {
        //update Card name color based on rarity
        nameText.color = rarityColors[(int)cardData.rarity];

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
