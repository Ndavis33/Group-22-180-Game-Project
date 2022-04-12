using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
public float speed;
public float radius;
    // Start is called before the first frame update
  

    // Update is called once per frame
   void Update()
    {
       if (radius == true)
       {
              transform.scale += 10f;
       }
    }
}
