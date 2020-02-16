using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    private Transform playerPosOne;
    private Transform playerPosTwo;
    public float speed = 5.0f;

// Use this for initialization
    void Start()
    {
        playerPosOne = playerOne.transform;
        playerPosTwo = playerTwo.transform;
    }

    void Update()
    {
        //float distanceOneX = Vector3.Distance(transform.position.x, playerPosOne.position.x);
        float distanceOneZ = Mathf.Abs(transform.position.z - playerPosOne.position.z);
        print("XXXXXXX " + distanceOneZ);
        float distanceOne = Vector3.Distance(transform.position, playerPosOne.position);    //Finds the distance between the enemy and player 1
        print("Distance One " + distanceOne);
        float distanceTwo = Vector3.Distance(transform.position, playerPosTwo.position);    //Finds the distance betwwen the enemy and player 2
        //print("Distance Two " + distanceTwo);

        if (distanceOne < distanceTwo)  //if player one is closer to the enemy than player two
        {
            MoveTo(playerPosOne);  //moves the enemy towards player 1
        }
        else//if player 2 is closer
        {
            MoveTo(playerPosTwo);  //moves the enemy towards player 2
        }
    }

    void MoveTo(Transform Target)
    {
        float dist = Vector3.Distance(transform.position, Target.position);

        if (dist > 1.25f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
    }
     
 }

//x and z position need to be within a certain amount