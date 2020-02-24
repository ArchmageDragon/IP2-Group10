using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //Class for the healthbar UI elements

    //Transform variable for the healthbar
    Transform healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //Finds (health)bar object to transform
        healthBar = transform.Find("Bar");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This is used to change the scale of the healthbar accroding to character's health percentage
    //I.e, if character's health is at 40%, health bar should also be at 40%, or as a scale of 0.4f
    public void SetSize(float sizeNormalised)
    {
        healthBar.localScale = new Vector3(sizeNormalised, 1f);
    }


}
