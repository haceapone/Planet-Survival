using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public SpawnerScript script;
    public bool finished1 = false;

    public void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            
        }
    }
    public void Update()
    {
        if (script.finished == true)
        {
            finished1 = true;
        }
    }
}
