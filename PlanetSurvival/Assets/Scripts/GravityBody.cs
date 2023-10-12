using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]

public class GravityBody : MonoBehaviour
{
    GravityAtractor planet;
    
    public void Awake()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAtractor>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        planet.Attract(transform);
    }
}
