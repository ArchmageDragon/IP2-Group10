using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(health);
    }

    void OnCollisionEnter(Collision other)
    {
        //could do it by tag or name depending on whats easier
        switch (other.gameObject.tag)
        {
            case "Enemy":
                health = health - 1;
                print("Hello there!");
                //Modify a stat
                //Something like damage += 50
                break;
            default:
                break;
        }
    }
}
