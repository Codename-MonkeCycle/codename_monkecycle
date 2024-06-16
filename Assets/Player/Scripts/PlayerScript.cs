using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int maxHp;
    public int currentShield;
    private int currentHp;
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (currentShield >= 0) 
        { 
            currentHp -= damage - currentShield;
            currentShield -= damage;
            if (currentShield < 0) { currentShield = 0; }
        }
        else currentHp -= damage;
    }
    public void HealDamage(int heal)
    {
        currentHp += heal;
    }
    public void ShieldUp(int shield)
    {
        currentShield += shield;
    }
}
