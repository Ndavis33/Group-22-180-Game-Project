using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteButton : MonoBehaviour
{
    public GameObject redDoor;
    public GameObject blueDoor;
    public GameObject greenDoor;
    private float delay = 3;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(doorsDelay());
        }
    }

    IEnumerator doorsDelay()
    {
        redDoor.gameObject.SetActive(false);
        blueDoor.gameObject.SetActive(false);
        greenDoor.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);
        redDoor.gameObject.SetActive(true);
        blueDoor.gameObject.SetActive(true);
        greenDoor.gameObject.SetActive(true);
    }
}
