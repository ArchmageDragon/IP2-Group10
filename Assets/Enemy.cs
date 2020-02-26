using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //enemy's animator
    public Animator animator;

    //References tot the two player characters
    public GameObject playerOne;
    public GameObject playerTwo;

	//Positions of the two player characters
    private Transform playerPosOne;
    private Transform playerPosTwo;
	
    private GameObject target;
	
    private Vector2 randomRoamPos;
    private Vector2 roamPos;
    private Vector2 behindPoint;
	
    int roamCheck = 0;
    int behindCheck = 0;
	
    bool check = true;
    bool leftRight;
	
    int test = 0;

    float enemyOldX;
    float enemyNewX;

    public float speed = 0.75f;

<<<<<<< Updated upstream
    float enemyOldX;
    float enemyNewX;

    public float speed = 5.0f;
=======
    public Rigidbody2D enemy;

    SpriteRenderer m_SpriteRenderer;
>>>>>>> Stashed changes

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
        //Sets up reference of the two player characters
        playerOneHealth = playerOne.GetComponent<Health_P>();
        playerTwoHealth = playerTwo.GetComponent<Health_P>();

		//Sets up reference to enemy's own health
        enemyHealth = GetComponent<Health_E>();

		//Sets up references of the two player characters' location
        playerPosOne = playerOne.transform;
        playerPosTwo = playerTwo.transform;

<<<<<<< Updated upstream
        enemy = GetComponent<Rigidbody2D>();

=======
		//
        enemy = GetComponent<Rigidbody2D>();
        
>>>>>>> Stashed changes
    }

    void Update()
    {
<<<<<<< Updated upstream
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
=======
		//********** Testing the different states the enemy can be in
        if(Input.GetKeyDown(KeyCode.Space))
        {
			//**** Makes sure we can circle between enemy states
			if(test >= 3)
			{
				test = 0;
			}
			
			else
			{
				test++;
			}
        }

		//The different states enemy can be in
        switch(test)
>>>>>>> Stashed changes
        {
            case 0:
                RandomRoam();
                print("Random Roam");
                break;
				
            case 1:
                Move(false);
                print("Chase");
                break;
				
            case 2:
                StartCoroutine(Roam());
                print("Roam");
                break;
				
            case 3:
                Behind();
                print("Move Behind");
                break;
        }
		
        //RandomRoam();
        //Move(false);
        //Move(true);
        //StartCoroutine(Roam());
        //Behind();
        //StartCoroutine(MoveBehind(playerOne));
        //MoveBehind(playerOne);

		//Gets SpriteRenderer of enemy object
		//This is so enemy can  flip as intended
        m_SpriteRenderer = GetComponent<SpriteRenderer>();


<<<<<<< Updated upstream
        else if (distanceOne > distanceTwo && playerTwo.activeSelf == true) //if player 2 is closer //distanceOne > distanceTwo && 
=======
        //****** Game ends when both players are defeated
        if (playerOne.activeSelf == false && playerTwo.activeSelf == false)
>>>>>>> Stashed changes
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
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

<<<<<<< Updated upstream
        if (dist > 1.4f)
=======
		//Player should only be attacked if they are "physically" attacked as well
		//Therefore, they won't get actually attacked until they are close enough to the enemy
        if (dist > 1.25f)
>>>>>>> Stashed changes
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

            //****** Store previous X position
            enemyOldX = enemy.position.x;

            enemy.MovePosition(Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime) );

            //****** Store new X position
            enemyNewX = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime).x;

            //****** Not very elegant way to flip the enemy sprites...
            //Pretty much checks enemy's movement direction versus previous direction
			//If these two are different, enemy will be flipped accordingly
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

<<<<<<< Updated upstream
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
=======
	//Enemy randomly roams on the (visible area of the) level 
	void RandomRoam()
	{
		
		if(randomRoamPos.Equals(transform.localPosition))
		{
			float roamX = Random.Range(-1,1);
			float roamY = Random.Range(-1,1);

			randomRoamPos = transform.localPosition;
            randomRoamPos.x += roamX;
            randomRoamPos.y += roamY;				
		}

		transform.position = Vector2.MoveTowards(transform.position, randomRoamPos, speed * Time.deltaTime);
			
	}

	///void Flee()
	//{
		//Move(true);
	//}
	
	void Move(bool run)
	{
		//Calculates the distance between enemy and player one, and between enemy and player 2
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

    //void Roam()
    //{
    //    //set  new point 1 up and 1 back
    //    //move enemy to new point
    //    //set point 2 down
    //    //move enemy to new point
    //    //back to move method

    //    float step = 0.1f * Time.deltaTime;
    //    while (x <= 2)
    //    {
    //        if (check)
    //        {
    //            switch(x)
    //            {
    //                case 0:
    //                    roamPos = transform.localPosition;
    //                    roamPos.x += 1;
    //                    roamPos.y += 1;
    //                    check = false;
    //                    print("1");
    //                    break;
    //                case 1:
    //                    roamPos = transform.localPosition;
    //                    roamPos.y -= 2;
    //                    check = false;
    //                    print("2");
    //                    break;
    //                default:
    //                    break;
    //            }
    //        }
            
    //        if (roamPos.Equals(transform.localPosition))
    //        {
    //            //transform.position = Vector2.MoveTowards(transform.position, roamPos, speed * Time.deltaTime);
                
    //            x++;
    //            check = true;
    //            print("3");
    //        }
           
    //            //x++;
    //           // check = true;
    //            transform.position = Vector2.MoveTowards(transform.position, roamPos, step);
    //            //print("4");
            
    //    }
    //}

    public IEnumerator Roam()
    {
        while (roamCheck < 2)
        {
            if (check)
            {
                switch (roamCheck)
                {
                    case 0:
                        roamPos = transform.localPosition;
                        roamPos.x += 1;
                        roamPos.y += 1;
                        check = false;
                        break;
						
                    case 1:
                        roamPos = transform.localPosition;
                        roamPos.y -= 2;
                        check = false;
                        break;
						
                    default:
                        break;
                }
            }

            if (roamPos.Equals(transform.localPosition))
            {
                //transform.position = Vector2.MoveTowards(transform.position, roamPos, speed * Time.deltaTime);

                roamCheck++;
                check = true;
                print("3");
            }

            //x++;
            // check = true;
            transform.position = Vector2.MoveTowards(transform.position, roamPos, 0.1f * Time.deltaTime);
            //print("4");

            yield return null;
        }
    }

    void Behind()
    {
        //determine a point behind the player based on what direction they are facing
        //move stright up, then along behind the player and then straight down to the point
        //go back into chase mode or just go to chase mode once behind the player and within a certain distance

        float distanceOne = Vector2.Distance(transform.position, playerPosOne.position);
        float distanceTwo = Vector2.Distance(transform.position, playerPosTwo.position);
		
        // go for the closest player
        if(distanceOne < distanceTwo && playerOne.activeSelf == true)
        {
            target = playerOne;
        }
        else if(distanceOne > distanceTwo && playerTwo.activeSelf == true)
        {
            target = playerTwo;
        }

        //need to determine if the enemy is already behind the player
        //then we go back to move mode
        //take the enemy position and the player position
        // find out what side of the player the enemy is on
        // then find out what side the player is facing
        // if the player is facing the same side the enemy is on then move beghind them
        //if not then the enemy is already behind them

        float distanceA = Vector2.Distance(transform.position, new Vector2(100, 0));
        float distanceB = Vector2.Distance(target.transform.position, new Vector2(100, 0));

        // false for left true for right
        if (distanceA < distanceB)
        {
            
            leftRight = true;
            print("Right");
        }
        else
        {
            leftRight = false;
            print("Left");
        }

        // determine what way the player is facing
        //true for right false for left
        bool targetLeftRight = target.GetComponent<SpriteRenderer>().flipX;

        if(leftRight == true && targetLeftRight == true)
        {
            print("Behind");
            StartCoroutine(MoveBehind(target));
        }
        else if(leftRight == false && targetLeftRight == false)
        {
            print("Behind");
            StartCoroutine(MoveBehind(target));
        }
        else
        {
            print("Front");
        }
    }

    public IEnumerator MoveBehind(GameObject Target)
    {
        //find points to move the enemy behind the player
        // once it runs it must keep going despite the player changing direction
        //
        
        print(behindPoint);

        while (behindCheck < 3)
        {
            if (check)
            {

                switch (behindCheck)
                {
                    case 0:
                        behindPoint.x = transform.position.x;
                        behindPoint.y = Target.transform.position.y + 2;
                        check = false;
                        break;
						
                    case 1:
                        behindPoint.x = behindPoint.x + (Target.transform.position.x - transform.position.x) + (2 * (Target.transform.position.x - transform.position.x) / Mathf.Abs(Target.transform.position.x - transform.position.x));
                        check = false;
                        break;
						
                    case 2:
                        behindPoint.y = Target.transform.position.y;
                        check = false;
                        break;
						
                    default:
                        break;

                }
            }

            if (behindPoint.Equals(transform.localPosition))
            {
                behindCheck++;
                check = true;
            }

            transform.position = Vector2.MoveTowards(transform.position, behindPoint, speed / 10 * Time.deltaTime);

            yield return null;
        }
    }
 }
>>>>>>> Stashed changes
