using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{

    Medikit mediKit;

    Health_P playerHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D (Collision2D other)
    {
        //could do it by tag or name depending on whats easier


        if (gameObject.tag == "Player")
        {
            switch (other.gameObject.tag)
            {
                case "Medikit":

                    mediKit = other.gameObject.GetComponent<Medikit>(); ;

                    playerHealth = gameObject.GetComponent<Health_P>();

                    //increase player's health
                    playerHealth.MedikitPickedUp(mediKit.medikitHealValue);

                    Destroy(other.gameObject);
                    break;

                default:
                    break;
            }
        }
    }
}