using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RedButton : MonoBehaviour
{
    public GameObject redDoor;
    public float redDelay;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(doorDelayRed());
        }
    }

    IEnumerator doorDelayRed()
    {
        redDoor.gameObject.SetActive(false);
        yield return new WaitForSeconds(redDelay);
        redDoor.gameObject.SetActive(true);
    }
}
