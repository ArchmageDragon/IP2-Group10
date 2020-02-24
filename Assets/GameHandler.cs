using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    //This class is for handling various elements such as UI in the scene

    //Variables for the healthbars
    //Needs corresponding Healthbar objects attached in Unity's Editor
    [SerializeField] private HealthBar playerOneHealthBar;
    [SerializeField] private HealthBar playerTwoHealthBar;

    //Variables for the player characters
    //Needs corresponding Payer objects attached in Unity's Editor
    [SerializeField] private Health_P playerOneHealth;
    [SerializeField] private Health_P playerTwoHealth;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if player one's health is above zero
        if (playerOneHealth.healthPercent > 0)
        {
            //Set player one's healthbar to represent their actual health
            playerOneHealthBar.SetSize(playerOneHealth.healthPercent);
        }
        //If player one's health reaches zero, their healthbar gets disabled
        else
        {
            playerOneHealthBar.gameObject.SetActive(false);
        }

        //Checks if player two's health is above zero
        if (playerTwoHealth.healthPercent > 0)
        {
            //Set player two's healthbar to represent their actual health
            playerTwoHealthBar.SetSize(playerTwoHealth.healthPercent);
        }
        //If player two's health reaches zero, their healthbar gets disabled
        else
        {
            playerTwoHealthBar.gameObject.SetActive(false);
        }

    }
}
