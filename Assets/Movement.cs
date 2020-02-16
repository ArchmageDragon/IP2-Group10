using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float direction = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += 1 * direction * Time.deltaTime;
        transform.localPosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1.0f;
        }
        else
        {
            direction = 0.0f;
        }
    }
}
