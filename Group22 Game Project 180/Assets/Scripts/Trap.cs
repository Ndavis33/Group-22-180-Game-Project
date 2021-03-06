using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
public float speed;
public bool goingLeft;
    // Start is called before the first frame update
    private void Start()
    {
        float despawnTime = 3f;
        StartCoroutine(Despawn(despawnTime));
    }

    // Update is called once per frame
    void Update()
   {
       if (goingLeft == true)
       {
              transform.position += speed* Vector3.left * Time.deltaTime;
       }
   }

    //despawns traps after despawnTime
    IEnumerator Despawn(float despawnTime)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
