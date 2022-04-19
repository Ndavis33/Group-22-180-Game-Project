using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: [Grant Stewart]
 * Date:   [04-18-22]
 *         [Sets movement for Zippy enemies]
 */         

public class ZippyMove : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    public GameObject upPoint;
    public GameObject downPoint;
    public GameObject midPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    private Vector3 upPos;
    private Vector3 downPos;
    private Vector3 midPos;
    public int speed;
    private bool goingLeft = true;
    private bool goingRight = false;
    private bool goingUp = false;
    private bool goingDown = false;
    private bool atMid;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        //Left position grabs the transform from the leftPoint GameObject
        leftPos = leftPoint.transform.position;

        //Right postion grabs the transform from the rightPoint GameObject
        rightPos = rightPoint.transform.position;

        //upPos grabs the transform from the upPoint object
        upPos = upPoint.transform.position;

        //downPos grabs the transform from the downPoint object
        downPos = downPoint.transform.position;

        //midPos grabs the transform from the midPoint onject
        midPos = midPoint.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    //Move left-mid, right-mid, up-mid, down-mid for enemy
    private void move()
    {
        //if the enemy is going left
        if (goingLeft)
        {
            
            atMid = false;
    
            //if the enemy's x position is less than or equal to the leftPos
            if (transform.position.x <= leftPos.x)
            {
                while (atMid == false)
                {
                    if (transform.position.x >= midPos.x)
                    {
                        atMid = true;
                        goingLeft = false;
                        goingRight = true;
                    }
                    else
                    {
                        transform.position += Vector3.right * Time.deltaTime * speed;
                    }
                }



            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        //When the enemy is going right
        if (goingRight)
        {
            atMid = false;
            //if the enemy's position is greater than or equal to the rightPos
            if (transform.position.x >= rightPos.x)
            {
                while (atMid == false)
                {
                    transform.position += Vector3.left * Time.deltaTime * speed;
                    if(transform.position.x <= midPos.x)
                    {
                        atMid = true;
                        goingRight = false;
                        goingUp = true;
                        
                    }
                }
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
        //When the enemy is going up
        if (goingUp)
        {
            atMid = false;
            //if the enemies position is greater than or equal to the upPos
            if (transform.position.z >= upPos.z)
            {
                while (atMid == false)
                {
                    transform.position += Vector3.back * Time.deltaTime * speed;
                    if(transform.position.z <= midPos.z)
                    {
                        atMid = true;
                        goingUp = false;
                        goingDown = true;
                        
                    }
                }
            }
            else
            {
                transform.position += Vector3.forward * Time.deltaTime * speed;
            }
        }
        //When enemy is going down
        if (goingDown)
        {
            atMid = false;
            if (transform.position.z <= downPos.z)
            {
                while (atMid == false)
                {

                    if(transform.position.z <= midPos.z)
                    {
                        atMid = true;
                        goingDown = false;
                        goingLeft = true;
                    }
                    else
                    {
                        transform.position += Vector3.forward * Time.deltaTime * speed;

                    }
                }
            }
            else
            {
                transform.position += Vector3.back * Time.deltaTime * speed;
            }
        }
    }
    //deactivates if hit by player shockwave
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "shockwave")
        {
            this.gameObject.SetActive(false);
        }
    }
}
