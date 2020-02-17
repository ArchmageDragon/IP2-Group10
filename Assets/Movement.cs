using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float directionX = 0.0f;
    float directionY = 0.0f;
    bool facedirection = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += 1 * directionX * Time.deltaTime;
        position.z += 1 * directionY * Time.deltaTime;
        transform.localPosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            directionX = 1.0f;
            facedirection = true;
            //if (!facedirection)
            //{
            //    gameObject.transform.Rotate(0.0f, 0.0f, 0.0f);
            //    facedirection = true;
            //}
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            directionX = -1.0f;
            if (facedirection)
            {
                gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
                facedirection = false;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            directionY = 1.0f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            directionY = -1.0f;
        } 
        else
        {
            directionX = 0.0f;
            directionY = 0.0f;
        }

       // while(facedirection == true)
       // {
       //     gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
       // }
    }
}
