using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToutchingCollider : MonoBehaviour
{

    private bool colliding = false;
    private float cn = 10f;

    // Start is called before the first frame update
    private void OnCollisionStay(Collider other)
    {
        if (other.gameObject.tag == "Planet")
        {
            colliding = true;
            Debug.Log("true");
        }
        
    }

    private void Update()
    {
        cn -= 0.01f;
        if (cn == 0f)
        {
            AfterTime();
        }
    }

    private void AfterTime()
    {
        if (colliding == false)
        {
            Destroy(this.gameObject);
            Debug.Log("true");
        }
    }
}
