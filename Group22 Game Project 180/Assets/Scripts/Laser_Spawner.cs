using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Spawner : MonoBehaviour
{
    [Header("Projectile Variables")]
    public bool goingLeft;
    [Header("Spawner Variables")]
    public float timeBetweenShots;
    public float startDelay;
    public GameObject Laser_PreFab;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("Laser_Drip",startDelay, timeBetweenShots );

    }

   
    public void Laser_Drip ()
    {
       GameObject projectiles = Instantiate(Laser_PreFab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        if (projectiles.GetComponent<Laser_Shot>())
        {
            projectiles.GetComponent<Laser_Shot>().goingLeft = goingLeft;
        }
    }
}
