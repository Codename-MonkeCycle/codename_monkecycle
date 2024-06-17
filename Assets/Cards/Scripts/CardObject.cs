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
        public Image image;
        public int cost;
        public Rarity rarity;
        public string cardDesc;
        public int heal;
        public int shield;
        public int damage;
        public int status1;
        public int status2;
        public TargetType targetType;
        public string target;



        //public StatusEffect statusEffect;


        public enum Rarity
        {
            Common,
            Rare,
            Mythic
        }

        public enum RarityColor
        {
            Black,
            Blue,
            Magenta
        }
        public enum TargetType
        {
            Self,
            Enemy
        }

    }
}
