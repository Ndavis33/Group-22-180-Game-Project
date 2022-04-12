using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
*Author:[Davis, Nathan]
*Date [03/23/2022
*solves Platfrom1]
*/


public class PlayerMovement : MonoBehaviour
{

    public int speed = 1;
    private Rigidbody rigid_body;
    public float jump_force = 100;
    public bool isGrounded;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text gameOverText;
    private int count;
    public int lives = 3;
    public int fallDepth;
    private Vector3 startPosition;
    public float stunTimer;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigid_body = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movejump();
    // Shoots beam at ground to check if ground is actrually there
       RaycastHit hit; 
       if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKey("space")&& isGrounded)
        {
            rigid_body.AddForce(Vector3.up * jump_force);
        }

    }

 //the Fixed jump moved into its own funtion 
    void Movejump()
    {
        Vector3 add_position = Vector3.zero;

        if (Input.GetKey("a"))
        {
            add_position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))
        {
            add_position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKeyDown("space"))
        {
            rigid_body.AddForce(Vector3.up * jump_force);
        }
        GetComponent<Transform>().position += add_position;

        if(transform.position.y < fallDepth)
        {
            Respawn();
        }
    }

    // Respawn function
    private void Respawn()
    {
        transform.position = startPosition;
        lives--;
        SetCountText();

        if(lives <=0)
        {
            this.enabled = false;
        }
    }
   //collider to set game object off
  void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
           other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.tag == "Enemy")
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f))
            {
                isGrounded = true;
                other.gameObject.SetActive(false);
            }
            else
            {
                isGrounded = false;
               
                Respawn();
            }
          

        }
        if(other.gameObject.tag == "Hazard")
        {
            Respawn();
        }
        if(other.gameObject.tag == "DrippingIce")
        {
            Respawn();
        }
        if (other.tag == "Laser")
        {
            StartCoroutine(Stun());
        }

        
    }

    // shows the text on the UI
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        livesText.text = "Lives: " +lives.ToString();

        if(lives <=0)
        {
            gameOverText.text = "GameOver You Lose !";
        }

        if(count >= 6)
        {
            winText.text = "You Win!";

        }
    }

    IEnumerator Stun()
    {
        int currentPlayerSpeed = speed;
        speed = 1;
            yield return new WaitForSeconds(stunTimer);
        speed = currentPlayerSpeed;
    }




   

}
