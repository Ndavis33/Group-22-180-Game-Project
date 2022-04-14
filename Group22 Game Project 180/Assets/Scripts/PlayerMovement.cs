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
    public GameObject shockWave;


    // Start is called before the first frame update
    void Start()
    { 
        shockWave.SetActive(false);
        startPosition = transform.position;
        rigid_body = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetCountText();
       

    }

    // Update is called once per frame
    void Update()
    {
        Movejump();
        // Shoots beam at ground to check if ground is actrually there

       
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
        if (Input.GetKey("w"))
        {
            add_position += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey("s"))
        {
            add_position += Vector3.back * Time.deltaTime * speed;
        }
      
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Shock());
        }
        GetComponent<Transform>().position += add_position;

        if(transform.position.y < fallDepth)
        {
            Respawn();
        }
    }

    IEnumerator Shock()
    {
        shockWave.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        shockWave.SetActive(false);
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
        if (other.tag == "Scene 1")
        {
            Scene_Switch.instance.switchScene(1);
        }
        if (other.tag == "Scene 2")
        {
            Scene_Switch.instance.switchScene(2);
        }
        if (other.tag == "Scene 3")
        {
            Scene_Switch.instance.switchScene(3);
        }
        if (other.tag == "Boss Scene")
        {
            Scene_Switch.instance.switchScene(4);
        }

        if (other.tag == "Laser")
        {
            StartCoroutine(Stun());
        }

        
    }

    // shows the text on the UI
    void SetCountText()
    {
        countText.text = "Red Key: " + count.ToString();
        livesText.text = "Hearts: " +lives.ToString();

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
