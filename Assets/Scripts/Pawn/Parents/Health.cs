using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public  class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Image healthBar;
    bool didHit;
    public AudioSource hit;
    
    // Start is called before the first frame update
    public  void Start()
    {
        didHit = false;
        //Sets start health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public  void Update()
    {
        healthBar.fillAmount = currentHealth / 100;
    }
    public  void TakeDamage(float damageDone, Pawn source)
    {
<<<<<<< HEAD
        currentHealth = currentHealth - damageDone;
        didHit = true;
      //Stops health from going above/below 100 or 0
      currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
      if (source != null&&didHit)
      {
            hit.Play();
            didHit = false;
            
            Debug.Log(source.name + " did " + damageDone + " damage to " + gameObject.name);
      }
      if (currentHealth <= 0)
      {
            if(source != null)
            {
                Die(source);
            }
=======
      currentHealth = currentHealth - damageDone;
      //Stops health from going above/below 100 or 0
      currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
      if (source != null)
      {
       Debug.Log(source.name + " did " + damageDone + " damage to " + gameObject.name);
      }
      if (currentHealth <= 0)
      {
           Die(source);
>>>>>>> main
      }
    }
    public  void Die(Pawn source)
    {
        Destroy(gameObject);
    }
<<<<<<< HEAD
    public  void Heal(float healingDone, Pawn pawn)
=======
    public void Heal(float healingDone, Pawn pawn)
>>>>>>> main
    {
            currentHealth = currentHealth + healingDone;
            //Stops health from going above/below 100 or 0
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
