using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Drip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.y < 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
