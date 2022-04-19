using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: [Grant Stewart]
 * Date:   [04-08-22]
 *         [Spawns key when all enemies are defeated]
 */

public class BlueKey : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public bool enemiesGone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //enables/disables key based on status of all enemies
        if (enemiesGone == true)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    //checks if all enemies are deactive
    private bool SpawnCheck()
    {
        if(enemy1.gameObject.activeInHierarchy==false && enemy2.gameObject.activeInHierarchy==false && enemy3.gameObject.activeInHierarchy==false && enemy4.gameObject.activeInHierarchy==false && enemy5.gameObject.activeInHierarchy == false)
        {
            return enemiesGone = true;
        }
        else
        {
            return enemiesGone = false;
        }
    }
}
