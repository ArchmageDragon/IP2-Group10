using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Character's base health
    //Made public for easy editing in Unity
    public float startingHealth;

    //Character's current health
    float currentHealth;

    //Health percenateg of character
    public float healthPercent;

    //Bool value to check whether a character is defeated or not
    //By default, they are not, therefore starting value is "false"
    //bool isDefeated = false;


    void Awake()
    {
        //Sets the current health of the character to its starting health at the beginning
        currentHealth = startingHealth;

        //Sets healtbar percentage
        CharacterHealthBarPercentage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Runs when character is hit or damaged in some way
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

        //Updates healthbar
        CharacterHealthBarPercentage();
    }

    //Runs when a "Medikit" tagged object was picked up
    //****May need to move to Health_P as enemies might not need healing at all! ****
    public void MedikitPickedUp(int healValue)
    {
        print("Health for " + gameObject.name + " was " + currentHealth);

        //Reduces character's health by damage taken
        currentHealth += healValue;

        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }

        print("Current health for " + gameObject.name + " is " + currentHealth);

        //Updates healthbar
        CharacterHealthBarPercentage();

    }

    //Checks if character was defeated
    //If defeated, character gets disabled
    void CharacterDefeated()
    {
        //isDefeated = true;    

        gameObject.SetActive(false);

    }

    //Calculate the health percentage of character
    //Uses currentHealth and startingHealth
    //I.e. c.H = 7, s.H = 10, then health percentage is 70%, or 0.7f
    void CharacterHealthBarPercentage()
    {
        healthPercent = currentHealth / startingHealth;

    }

    

}
