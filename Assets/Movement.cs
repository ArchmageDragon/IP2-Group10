using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Float variables to change player character's initial X and Y position
    float directionX = 0.0f;
    float directionY = 0.0f;

    //used to store SPriteRenderer information of player character's sprite
    SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //Update player character's position

        Vector2 position = transform.localPosition;
        position.x += 1 * directionX * Time.deltaTime;
        position.y += 1 * directionY * Time.deltaTime;
        transform.localPosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        //---------- This part is for moving the 2 player characters ----------
        //
        //
        //Keyboard movemet for male player character
        if (gameObject.name == "PlayaBoi")
	    {
            //Test to see if check runs
		    //print("I'm a real boy!");

            //Press D to go right
		    if(Input.GetKey(KeyCode.D))
        	{
          	    directionX = 1.0f;

                //Flips character
                m_SpriteRenderer.flipX = false;

               }

            //Press A to go left
       		else if (Input.GetKey(KeyCode.A))
        	{
            	directionX = -1.0f;

                //Flips character
                m_SpriteRenderer.flipX = true;

            }

            //Press W to go up
        	else if (Input.GetKey(KeyCode.W))
        	{
            	directionY = 1.0f;
        	}

            //Press S to go down
        	else if (Input.GetKey(KeyCode.S))
        	{
            	directionY = -1.0f;
        	} 

            //Remain stationery when no key is pressed
        	else
        	{
                directionX = 0.0f;
                directionY = 0.0f;
        	}
	    }
        //
        //
        //Keyboard movement for female player character
        else if (gameObject.name == "PlayaGal")
	    {
            //Test to see if check runs
            //print("I'm a real girl!");

            //Press Right Arrow key to move right
            if (Input.GetKey(KeyCode.RightArrow))
        	{
          	    directionX = 1.0f;

                //Flips character
                //******** EDIT FOR FINAL SPRITE!
                m_SpriteRenderer.flipX = true;
            }

            //Press Left Arrow key to move left
            else if (Input.GetKey(KeyCode.LeftArrow))
        	{
                //Flips character
                //******** EDIT FOR FINAL SPRITE!
                directionX = -1.0f;
                m_SpriteRenderer.flipX = false;
            }

            //Press Up Arrow key to move up
            else if (Input.GetKey(KeyCode.UpArrow))
        	{
            	directionY = 1.0f;
        	}

            //Press Down Arrow key to move down
            else if (Input.GetKey(KeyCode.DownArrow))
        	{
            	directionY = -1.0f;
        	}

            //Remain stationery when no key is pressed
            else
            {
                directionX = 0.0f;
            	directionY = 0.0f;
        	}
	    }
        //
        
    }
}
