using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Shot : MonoBehaviour
{
public float speed;
public bool goingLeft;
    // Start is called before the first frame update
  

    // Update is called once per frame
   void Update()
    {
       if (goingLeft == true)
       {
              transform.position += speed* Vector3.left * Time.deltaTime;
       }
    }
}
