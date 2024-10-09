using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToutchingCollider : MonoBehaviour
{

    public bool colliding = false;
    public double cn = 10f;
    public SetActive sc;
    


    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Friendly Planet") && (!other.CompareTag("Finish")))
        {
            colliding = true;
        }
        else if (other.CompareTag("Finish"))
        {
            colliding = false;
        }


    }

    public void Update()
    {
        cn = cn - 1 * Time.deltaTime;
        if (cn<1)
        {
            AfterTime();
        }
    }

    public void AfterTime()
    {
        if (colliding == false)
        {
            Destroy(this.gameObject);
        }
    }
}
