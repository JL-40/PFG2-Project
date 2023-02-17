using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Enemy
{
    public float respawnTimer;

    float chatTimer = 0f;

    public Dummy() 
    {
        health = 100;
        maxHealth = 100;
        speed = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chatTimer == 5f)
        {
            Debug.Log($"Player is at: {PlayerMovement.GetPlayerLocation()}");
            chatTimer = 0f;
        }

        chatTimer += Time.deltaTime;
    }
}
