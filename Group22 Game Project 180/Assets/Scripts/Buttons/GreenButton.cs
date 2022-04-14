using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
    public GameObject greenDoor;
    public float greenDelay;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(doorDelayGreen());
        }
    }

    IEnumerator doorDelayGreen()
    {
        greenDoor.gameObject.SetActive(false);
        yield return new WaitForSeconds(greenDelay);
        greenDoor.gameObject.SetActive(true);
    }
}


