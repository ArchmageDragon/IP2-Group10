using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    private Transform playerPosOne;
    private Transform playerPosTwo;
    private Vector2 roamPos;
    
    

    float enemyOldX;
    float enemyNewX;

    public float speed;

    public Rigidbody2D enemy;

    SpriteRenderer m_SpriteRenderer;

    //Base attack power of enemy
    public int atkPower = 1;

    //Reference to players' health
    Health_P playerOneHealth;
    Health_P playerTwoHealth;

    //Reference to enemy's health
    Health_E enemyHealth;

    //Boolean variable to check if enemy attacked the player
    //********** Just a test, so enemy won't kill player in milliseconds without moving
    bool playerWasAttacked = false;

    // Use this for initialization
    void Start()
    {
        playerOneHealth = playerOne.GetComponent<Health_P>();
        playerTwoHealth = playerTwo.GetComponent<Health_P>();

        enemyHealth = GetComponent<Health_E>();

        playerPosOne = playerOne.transform;
        playerPosTwo = playerTwo.transform;

        enemy = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
	//Roam();
	//Move(false);
	Move(true);

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Moves the enemy to the player that was determined to be closer
    //Target is the closest player character
    //********** Will likely need to adjust it once we start changing enemy behaviour! **********
    void MoveTo(Transform target, Health_P playerHealth, bool flee)
    {
        float dist = Vector2.Distance(transform.position, target.position);
	if(flee)
	{
	speed = -0.75f;
	}
	else
	{
	speed = 0.75f;
	}

        if (dist > 1.25f)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            //****** Store previous X position
            enemyOldX = enemy.position.x;

            enemy.MovePosition(Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime) );

            //****** Store new X position
            enemyNewX = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime).x;

            //****** Not very elegant way to flip the enemy sprites...
            //print(enemyOldX);
            //print(enemyNewX);
            //
            if (enemyOldX > enemyNewX)
            {
                //print("Business");
                m_SpriteRenderer.flipX = false;
            }
            //
            else if (enemyOldX < enemyNewX)
            {
                //print("As usual");
                m_SpriteRenderer.flipX = true;
            }
            //****

            playerWasAttacked = false;
        }

        else
        {
            if (!playerWasAttacked)
            {
                playerHealth.DamageTaken(atkPower);

                playerWasAttacked = true;
            }
            
        }    
    }

	void Roam()
	{
		
		if(roamPos.Equals(transform.localPosition))
		{
			float roamX = Random.Range(-1,1);
			float roamY = Random.Range(-1,1);

			roamPos = transform.localPosition;
			roamPos.x += roamX;
			roamPos.y += roamY;
				
		}

		transform.position = Vector2.MoveTowards(transform.position, roamPos, speed * Time.deltaTime);
			
	}

	///void Flee()
	//{
		//Move(true);
	//}
	
	void Move(bool run)
	{
		
		float distanceOne = Vector2.Distance(transform.position, playerPosOne.position);
		float distanceTwo = Vector2.Distance(transform.position, playerPosTwo.position);

		if (distanceOne < distanceTwo && playerOne.activeSelf == true)  //if player one is closer to the enemy than player two
        	{
            		MoveTo(playerPosOne, playerOneHealth, run);  //Call MoveTo method; moves the enemy towards player 1
        	}
		else if (distanceOne > distanceTwo && playerTwo.activeSelf == true) //if player 2 is closer
        	{
            		MoveTo(playerPosTwo, playerTwoHealth, run);  //Call MoveTo method; moves the enemy towards player 2
        	}
	}
 }