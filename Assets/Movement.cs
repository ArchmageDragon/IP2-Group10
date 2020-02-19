using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    float directionX = 0.0f;
    float directionY = 0.0f;

    public float speed;

    public Rigidbody2D player;
    Vector2 movement;

    //used to store SpriteRenderer information of player character's sprite
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

        MoveChar();

        //---------- This part is for moving the 2 player characters ----------
        //
        //
        
        //
        
    }

    void MoveChar()
    {
        //Checks if player character is the boy...
        if (gameObject.name == "PlayaBoi")
        {
            directionX = Input.GetAxis("Horizontal_P1") * speed;
            directionY = Input.GetAxis("Vertical_P1") * speed;

            //****** Move this out of PlayaBoi once sprites are finalized! ********
            if (directionX > 0.0f)
            {
                m_SpriteRenderer.flipX = false;
            }
            else if (directionX < 0.0f)
            {
                m_SpriteRenderer.flipX = true;
            }

        }

        //...or if player cahracter is the girl
        else if (gameObject.name == "PlayaGal")
        {
            directionX = Input.GetAxis("Horizontal_P2") * speed;
            directionY = Input.GetAxis("Vertical_P2") * speed;

            //****** Delete this part once sprites are finalized! ********
            //** Difference is due to placeholder sprite facing the wrong direction and I'm too lazy to flip it in Photoshop or sth, lol
            if (directionX > 0.0f)
            {
                m_SpriteRenderer.flipX = true;
            }
            else if (directionX < 0.0f)
            {
                m_SpriteRenderer.flipX = false;
            }
        }

        movement = new Vector2(directionX, directionY);
        player.velocity = movement * speed;

    }
}
