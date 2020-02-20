using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    private Transform playerPosOne;
    private Transform playerPosTwo;

    float enemyOldX;
    float enemyNewX;

    public float speed = 5.0f;

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
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        //float distanceOneX = Vector2.Distance(transform.position.x, playerPosOne.position.x);
        float distanceOneZ = Mathf.Abs(transform.position.z - playerPosOne.position.z);
        //print("XXXXXXX " + distanceOneZ);

        //Finds the distance between the enemy and player 1
        float distanceOne = Vector2.Distance(transform.position, playerPosOne.position);
        //print("Distance One " + distanceOne);

        //Finds the distance betwwen the enemy and player 2
        float distanceTwo = Vector2.Distance(transform.position, playerPosTwo.position);    
        //print("Distance Two " + distanceTwo);

        if (distanceOne < distanceTwo && playerOne.activeSelf == true)  //if player one is closer to the enemy than player two
        {
            MoveTo(playerPosOne, playerOneHealth);  //Call MoveTo method; moves the enemy towards player 1
        }

        else if (distanceOne > distanceTwo && playerTwo.activeSelf == true) //if player 2 is closer //distanceOne > distanceTwo && 
        {
            MoveTo(playerPosTwo, playerTwoHealth);  //Call MoveTo method; moves the enemy towards player 2
        }

        if (playerOne.activeSelf == false && playerTwo.activeSelf == false)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        else if (playerOne.activeSelf == false)
        {
            MoveTo(playerPosTwo, playerTwoHealth);
        }
        else if (playerTwo.activeSelf == false)
        {
            MoveTo(playerPosOne, playerOneHealth);
        }
    }

    //Moves the enemy to the player that was determined to be closer
    //Target is the closest player character
    //********** Will likely need to adjust it once we start changing enemy behaviour! **********
    void MoveTo(Transform target, Health_P playerHealth)
    {
        float dist = Vector2.Distance(transform.position, target.position);

        if (dist > 1.4f)
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

   // void OnCollisionEnter2D (Collision other)
   // {
    //    if (gameObject.tag == "Enemy")
    //    {
    //        switch (other.gameObject.tag)
    //        {
               //case "Player":
                //    playerOneHealth.DamageTaken(atkPower);

     //           default:
     //               break;
     //       }
     //   }
}