using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Character's base health
    //Made public for easy editing in Unity
    public int startingHealth;

    //Character's current health
    int currentHealth;

    //Bool value to check whether a character is defeated or not
    //By default, they are not, therefore starting value is "false"
    //bool isDefeated = false;


    void Awake()
    {
        //Sets the current health of the character to its starting health at the beginning
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageTaken(int damageValue)
    {
        print("Health for " + gameObject.name + " was " + currentHealth);

        //Reduces character's health by damage taken
        currentHealth -= damageValue;

        print("Current health for " + gameObject.name + " is " + currentHealth);

        //Checks whether character's health reached 0
        //If health reaches 0, character is defeated
        if (currentHealth <= 0)
        {
            CharacterDefeated();
        }
    }

    public void MedikitPickedUp(int healValue)
    {
        print("Health for " + gameObject.name + " was " + currentHealth);

        //Reduces character's health by damage taken
        currentHealth += healValue;

        print("Current health for " + gameObject.name + " is " + currentHealth);

    }

    
    void CharacterDefeated()
    {
        //isDefeated = true;    

        gameObject.SetActive(false);

    }
    

}
