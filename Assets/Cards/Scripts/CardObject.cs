using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MonkeGame
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class CardObject : ScriptableObject 
    {
        public string cardName;
        public List<CardType> cardType;
        public int cost;
        public Rarity rarity;
        public string cardDesc;
        //public StatusEffect statusEffect;

        public enum CardType
        {
            Attack,
            Aoe,
            Defence,
            Heal,
            Status
        }

        public enum Rarity
        {
            Common,
            Rare,
            Mythic
        }
    }
}
