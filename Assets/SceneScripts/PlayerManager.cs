using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        Instantiate(player, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
