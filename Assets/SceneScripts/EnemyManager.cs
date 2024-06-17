using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public new Transform transform;
    void Start()
    {
        Instantiate(enemy, transform);
    }
}
