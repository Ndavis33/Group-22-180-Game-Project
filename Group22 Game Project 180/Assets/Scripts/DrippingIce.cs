using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrippingIce : MonoBehaviour
{
   public GameObject Ice_Drip_PreFab;
   public float delay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("IceDrip", 0f, delay);

    }

   
    public void IceDrip ()
    {
        Instantiate(Ice_Drip_PreFab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
    }
}
