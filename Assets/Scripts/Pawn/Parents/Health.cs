using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        //Sets start health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageDone, Pawn source)
    {
        currentHealth = currentHealth - damageDone;
        //Stops health from going above/below 100 or 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log(source.name + " did " + damageDone + " damage to " + gameObject.name);
        if(currentHealth <= 0)
        {
            Die(source);
        }
    }
    public void Die(Pawn source)
    {
        Destroy(gameObject);
    }
    public void Heal(float healingDone)
    {
        currentHealth = currentHealth + healingDone;
        //Stops health from going above/below 100 or 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
