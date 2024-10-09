using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public bool preko = true;
    public bool ustavi = false;
    public bool konecNapenjanja = false;
    public bool dolmoc = false;

    public float moc = 200f;
    public float procenti = 0f;

    public GameObject Jejc;
    public Rigidbody2D rb;

    public Slider forceUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            konecNapenjanja = true;
            Jejc.SetActive(true);

            rb.AddForce(transform.right * moc);
            StartCoroutine(Wait());
        }


        if (Input.GetKey(KeyCode.Space) && konecNapenjanja == false)
        {
            ustavi = true;
            if((moc < 1000f) && (dolmoc == false))
            {
                moc = moc + (300f * Time.deltaTime);
                slider();
            }
            else if(moc >= 1000f)
            {
                moc = moc - (300f * Time.deltaTime);
                dolmoc = true;
            }
            else if(dolmoc == true)
            {
                moc = moc - (300f * Time.deltaTime);
                if (moc < 200)
                {
                    dolmoc = false;
                    slider();
                }
            }
            slider();

            
        }
        else if(ustavi == false)
        {
            if (preko == true)
                if (transform.eulerAngles.z < 60f || transform.eulerAngles.z > 300f)
                {
                    transform.Rotate(0f, 0f, 20f * Time.deltaTime);

                }
                else
                {
                    preko = false;
                }
            if (preko == false)
                if (transform.eulerAngles.z < 00f || transform.eulerAngles.z < 300f)
                {
                    transform.Rotate(0f, 0f, -20f * Time.deltaTime);

                }
                else
                {
                    preko = true;
                }
        }

        void slider()
        {
            procenti = (moc - 200f) /800f;
            forceUI.value = procenti;
        }

        void resetGauge()
        {
            moc = 400;
            forceUI.value = 0;
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1.5f);
            resetGauge();
        }
    }
}
