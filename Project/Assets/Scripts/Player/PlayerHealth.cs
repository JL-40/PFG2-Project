using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    int maxHealth = 100; // Set the maximum health
    float hp = 0f;   // Current health of the player

    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHealth;     // Set the current health of the player

        healthText.text = hp.ToString();    // Display on the HUD the current player health
    }

    // Update is called once per frame
    void Update()
    {
        if (GetHealth() <= 25f)
        {
            healthText.color = Color.red;
        }
        else
        {
            healthText.color = Color.green;
        }
    }

    // Method for player taking damage
    public void TakeDamage(float damage)
    {
        // Check if the player health will NOT go into the negatives
        if (hp - damage >= 0)
        {
            hp -= Mathf.Ceil(damage);   // Reduce the player health by the damage the player would take. Round damage up.
        }
        else
        {
            hp = 0f;    // Player should not have less than 0 health.
        }

        healthText.text = hp.ToString();   // display to the player new health value
    }

    public void HealPlayer(float heal)
    {
        if (hp > 0 && hp < maxHealth)
        {
            hp += heal;

            Mathf.Ceil(hp);
        }

        healthText.text = hp.ToString();
    }

    // Get health of the player
    public float GetHealth() { return hp; }
}
