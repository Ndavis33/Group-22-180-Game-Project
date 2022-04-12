using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Spawner : MonoBehaviour
{
    [Header("Projectile Variables")]
    public bool grounded
    [Header("Spawner Variables")]
    public float timeBetweenShocks;
    public float startDelay;
    public GameObject sho;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("Laser_Drip",startDelay, timeBetweenShots );

    }

   
    public void Laser_Drip ()
    {
       GameObject shock = Instantiate(Laser_PreFab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        if (shock.GetComponent<Shockwave>())
        {
            shock.GetComponent<Shockwave>().goingLeft = goingLeft;
        }
    }
}
