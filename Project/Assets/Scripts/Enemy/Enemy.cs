using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public int maxHealth = 100;
    public float speed;

    public float damageDealt = 0f;
    public float damageResetTimer = 100f;
    protected bool resetDamageDealt = false;

    public bool isAlive = true;

    public TextMeshPro damageNumberText;

    void Awake()
    {
        damageNumberText.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        if (health > damage && health > 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;

            isAlive = false;
        }
    }

    public virtual void DisplayDamage(float damage)
    {
        if (!damageNumberText.gameObject.activeSelf)
        {
            damageNumberText.gameObject.SetActive(true);
        }

        damageDealt += damage;

        damageNumberText.text = damageDealt.ToString();

        if (resetDamageDealt)
        {
            damageDealt = 0f;
            damageNumberText.text = "0";

            damageResetTimer = 100f;

            damageNumberText.gameObject.SetActive(false);

            resetDamageDealt = false;
        }
    }
}
