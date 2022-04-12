using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: [Grant Stewart]
 * Date:   [03-01-2022]
 *         [This script will solve doors 2 lab by creating doors and keys]
 */

public class Player : MonoBehaviour
{
    public int lime_keys = 0;
    public int blue_keys = 0;
    public int red_keys = 0;
    public int gold_keys = 0;
    public int cyan_keys = 0;
    public int purple_keys = 0;

    private void OnTriggerEnter(Collider other)
    {
 
        //picks up lime orb
        if(other.gameObject.tag == "Lime Orb")
        {
            lime_keys++;
            print("Orb Green " + lime_keys);
            //print("Lime Orb - Tag you're it!");
            other.gameObject.SetActive(false);
        }

        //unlocks lime door
        if(other.gameObject.tag == "Lime Door")
        {
            print("The door is locked.");

            if ((lime_keys >= other.gameObject.GetComponent<Door>().number_of_locks_lime) && (cyan_keys >= other.gameObject.GetComponent<Door>().number_of_locks_cyan) && (gold_keys >= other.gameObject.GetComponent<Door>().number_of_locks_gold))
            {
                print("Lime door unlocked!");
                lime_keys -= other.gameObject.GetComponent<Door>().number_of_locks_lime;
                cyan_keys -= other.gameObject.GetComponent<Door>().number_of_locks_cyan;
                gold_keys -= other.gameObject.GetComponent<Door>().number_of_locks_gold;

                other.gameObject.SetActive(false);
            }
        }

        //picks up blue orb
        if(other.gameObject.tag == "Blue Orb")
        {
            blue_keys++;
            print("Orb Blue " + blue_keys);
            //print("Blue Orb added!");
            other.gameObject.SetActive(false);            
        }

        //unlocks blue door
        if (other.gameObject.tag == "Blue Door")
        {
            print("The door is locked.");

            if ((blue_keys >= other.gameObject.GetComponent<Door>().number_of_locks_blue) && (red_keys >= other.gameObject.GetComponent<Door>().number_of_locks_red) && (purple_keys >= other.gameObject.GetComponent<Door>().number_of_locks_purple))
            //if x>=2
            {
                print("Blue door unlocked!");
                blue_keys -= other.gameObject.GetComponent<Door>().number_of_locks_blue;
                red_keys -= other.gameObject.GetComponent<Door>().number_of_locks_red;
                purple_keys -= other.gameObject.GetComponent<Door>().number_of_locks_purple;
                other.gameObject.SetActive(false);
            }
        }

        //picks up red orb
        if (other.gameObject.tag == "Red Orb")
        {
            red_keys++;
            print("Orb Red " + red_keys);
            //print("Red Orb added!");
            other.gameObject.SetActive(false);
        }

        //unlocks red door
        if (other.gameObject.tag == "Red Door")
        {
            print("The door is locked.");

            if ((red_keys >= other.gameObject.GetComponent<Door>().number_of_locks_red) && (gold_keys >= other.gameObject.GetComponent<Door>().number_of_locks_gold))
            //if x>=2
            {
                print("Red door unlocked!");
                red_keys -= other.gameObject.GetComponent<Door>().number_of_locks_red;
                gold_keys -= other.gameObject.GetComponent<Door>().number_of_locks_gold;
                other.gameObject.SetActive(false);
            }
        }

        //picks up gold orb
        if (other.gameObject.tag == "Gold Orb")
        {
            gold_keys++;
            print("Orb Gold " + gold_keys);
            //print("Gold Orb added!");
            other.gameObject.SetActive(false);
        }

        //picks up cyan orb
        if (other.gameObject.tag == "Cyan Orb")
        {
            cyan_keys++;
            print("Orb Cyan " + cyan_keys);
            other.gameObject.SetActive(false);
        }

        //picks up purple orb
        if (other.gameObject.tag == "Purple Orb")
        {
            purple_keys++;
            print("Orb Purple " + purple_keys);
            other.gameObject.SetActive(false);
        }
    }
}  // end of Player Script
