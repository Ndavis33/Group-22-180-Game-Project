using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : MonoBehaviour
{
    public GameObject blueDoor;
    public float blueDelay;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(doorDelayBlue());
        }
    }

    IEnumerator doorDelayBlue()
    {
        blueDoor.gameObject.SetActive(false);
        yield return new WaitForSeconds(blueDelay);
        blueDoor.gameObject.SetActive(true);
    }

}
