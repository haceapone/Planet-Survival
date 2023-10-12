using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject spherePrefab;

    // Start is called before the first frame update

    

    void Start()
    {
        
        for(int i = 0; i<100; i++)
        {
            transform.position += new Vector3(1f, -100f, 0f);
            Instantiate(spherePrefab, transform.position, Quaternion.identity);
            for (int j = 0; j < 100; j++)
            {
                transform.position += new Vector3(0f, 1f, -100f);
                Instantiate(spherePrefab, transform.position, Quaternion.identity);
                for (int g = 0; g < 100; g++)
                {
                    transform.position += new Vector3(0f, 0f, 1f);
                    Instantiate(spherePrefab, transform.position, Quaternion.identity);
                }
            }
        }
        

        /*for (int i = 0; i < 10; i++)
        {
            transform.position += new Vector3(0f, 0.5f, 0f);
            Instantiate(spherePrefab, transform.position, Quaternion.identity);
        }
        for (int i = 0; i < 10; i++)
        {
            transform.position += new Vector3(0f, 0f, 0.5f);
            Instantiate(spherePrefab, transform.position, Quaternion.identity);
        }*/
    }
    

}
