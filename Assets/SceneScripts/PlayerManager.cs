using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    private HandManager handManager;

    void Start()
    {
        Instantiate(player, transform);
        handManager = FindObjectOfType<HandManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTurnStart()
    {
        player.GetComponent<PlayerScript>().energy = player.GetComponent<PlayerScript>().energy + 3;

    }
}
