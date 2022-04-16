using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 LeftPos;
    private Vector3 RightPos;
    public int speed;
    private bool goingUp;
    // Start is called before the first frame update
    void Start()
    {
        LeftPos = leftPoint.transform.position;

        RightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    //move function for enemy left and right
    private void move()
    {
        if(goingUp)
        {
            if(transform.position.x <= LeftPos.x)
            {
                goingUp = false;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else
        {
            if(transform.position.x >= RightPos.x)
            {
                goingUp = true;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }

}
