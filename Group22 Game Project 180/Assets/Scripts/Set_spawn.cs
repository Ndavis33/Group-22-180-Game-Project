using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Set_spawn : MonoBehaviour
{
    

    // Uses an empty game object to set a spawn point for the player when they die or travel to a new scene
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
       

    }

   
}
