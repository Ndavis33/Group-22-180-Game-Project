using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: [Grant Stewart]
 * Date:   [04-18-22]
 *         [sets parameters for trap object]
 */

public class TrapSpawner : MonoBehaviour
{
    //fancy parameter organization
    [Header("Projectile Variables")]
    public bool goingLeft;
    [Header("Spawner Variables")]
    public float timeBetweenShots;
    public float startDelay;
    public GameObject Trap_PreFab;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("Laser_Drip",startDelay, timeBetweenShots );

    }

   //instantiates trap
    public void Laser_Drip ()
    {
       GameObject projectiles = Instantiate(Trap_PreFab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        if (projectiles.GetComponent<Trap>())
        {
            projectiles.GetComponent<Trap>().goingLeft = goingLeft;
        }
    }
}
