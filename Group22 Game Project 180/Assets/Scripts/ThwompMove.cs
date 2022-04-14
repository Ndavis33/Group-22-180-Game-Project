using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: [Grant Stewart]
 * Date:   [04-04-2022]
 *         [Establishes thwomplike movement]
 */

/*public class ThwompMove : MonoBehaviour
{
    public GameObject upPoint;
    public GameObject downPoint;
    private Vector3 upPos;
    private Vector3 downPos;
    private int speed = 5;
    private bool goingUp = true;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        //Up position grabs the transform from the leftPoint GameObject
        upPos = upPoint.transform.position;

        //Down postion grabs the transform from the rightPoint GameObject
        downPos = downPoint.transform.position;

       // float waitTime = 3f;
        //StartCoroutine(FlyDelay(waitTime));
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    
    private void move()
    {

        if (goingUp)
        {
            //if the enemy's y position is less than or equal to the upPos
            if (transform.position.y >= upPos.y)
            {
                goingUp = false;
            }
            else
            {
                transform.position += Vector3.up * Time.deltaTime * speed;
            }
        }
        //if the enemy is not going up...
        else
        {
            //if the enemy's position is greater than or equal to the downPos
            if (transform.position.y <= downPos.y)
            {
                StartCoroutine(FlyDelay(waitTime));
                goingUp = true;
            }
            else
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
            }
        }
    }

    IEnumerator FlyDelay(float waitTime)
    {


            speed = 0;
            yield return new WaitForSeconds(waitTime);
            speed = 5;
        
        
    }
}
*/
