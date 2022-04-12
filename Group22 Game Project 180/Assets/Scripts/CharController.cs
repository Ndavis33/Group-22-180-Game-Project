using System.Collections;
using System.Collections.Generic;
using UnityEngine;





/*
 * 
 * DO NOT! edit this script create your own and add it as a compenant to this game object 
 * 
 * 
 * You may look at this script and try to understand it if you want some extra practice reading code though :D
 */
 
public class CharController : MonoBehaviour {

    //A boolean value that will tell you if you are within .1 Unity Unit from the ground
    private bool is_grounded;
    //The rigid body attached to the player
    private Rigidbody body;
    //how close are we to a wall on our left side
    private float distance_to_wall_left = 2f;
    //how close are we to a wall on our right side
    private float distance_to_wall_right = 2f;
    //how close are we to a wall going forward
    private float distance_to_wall_forward = 2f;
    //how close are we to a wall going backwards
    private float distance_to_wall_back = 2f;

    //Start is a function that is called once when the object is Instatiated. 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();

    }

    // Update is a function that is called once per frame
    void Update()
    {

        float translation = Input.GetAxis("Vertical") * 10 * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;

        if (!is_grounded)
            straffe /= 2;

        if (!is_grounded)
            translation /= 2;


        //if I'm too close to a wall, don't go that direction anymore
        if ((distance_to_wall_back <= .6 && translation < 0) || (distance_to_wall_forward <= .6 && translation > 0))
        {
            translation = 0;
        }
        if ((distance_to_wall_right < .6 && straffe > 0) || (distance_to_wall_left < .6 && straffe < 0))
        {
            straffe = 0;
        }

        //Translate to move.
        transform.Translate(straffe, 0, translation);




        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

    private void FixedUpdate()
    {
        DistanceToWall();
        Vector3 oldRot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, oldRot.y, 0);
    }

    private void DistanceToWall()
    {
        RaycastHit hit;
        Ray left_ray = new Ray(transform.position, -transform.right);
        Ray front_ray = new Ray(transform.position, transform.forward);
        Ray back_ray = new Ray(transform.position, -transform.forward);
        Ray right_ray = new Ray(transform.position, transform.right);

        //Raycast left to see if I find a wall
        if (Physics.Raycast(left_ray, out hit))
        {
            distance_to_wall_left = hit.distance;
        }
        else
        {
            distance_to_wall_left = 3;
        }

        //Raycast center forward to find a wall
        if (Physics.Raycast(front_ray, out hit))
        {
            distance_to_wall_forward = hit.distance;
        }
        else
        {
            distance_to_wall_forward = 3;
        }

        //Raycast center forward to find a wall
        if (Physics.Raycast(back_ray, out hit))
        {
            distance_to_wall_back = hit.distance;
        }
        else
        {
            distance_to_wall_back = 3;
        }

        //Raycast right to find a wall
        if (Physics.Raycast(right_ray, out hit))
        {
            distance_to_wall_right = hit.distance;
        }
        else
        {
            distance_to_wall_right = 3;
        }


        //Raycast down to find the ground
        if (Physics.Raycast(transform.position, -transform.up, 1.1f))
        {
            is_grounded = true;
        }
        else
        {
            is_grounded = false;
        }

    }
}
