using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHp = 20;
    public int damage;
    public int currentHp;
    public int blockStrength;
    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        CheckAlive();
    }
    private void CheckAlive()
    {
        if (currentHp <= 0) 
        {
            GameObject.Destroy(gameObject);
        }
    }
}
