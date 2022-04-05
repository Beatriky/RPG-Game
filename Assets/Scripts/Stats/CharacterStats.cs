using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    public Stat armor;
    public int maxHealth = 100;
    public int currentHealth {get; private set;}

    void Awake(){
        currentHealth = maxHealth;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.T)){
            TakeDamage(10);
        }
    }
    public void TakeDamage (int damage){

        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage , 0 , int.MaxValue);    //we dont want the damage to go lower than 0 -it has to be positive
        currentHealth -= damage;

        Debug.Log(transform.name + " takes "+ damage +" damage.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    
    public virtual void Die(){
        //die in some way
        Debug.Log(transform.name+" died");
    }
}
