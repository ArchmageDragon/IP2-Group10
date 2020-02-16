using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //could do it by tag or name depending on whats easier
        switch (other.gameObject.tag)
        {
            case "Weapon":
                Destroy(other.gameObject);
                //Modify a stat
                //Something like damage += 50
                break;
            default:
                break;
        }
    }
}
