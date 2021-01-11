using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPit : MonoBehaviour
    
{

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        //  Destroy(gameObject);
    //        Invoke("Chet", 1);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            // Destroy(gameObject);
            Invoke("Chet", 1/2);
        }
    }
    void Chet()
    {
        Destroy(gameObject);
    }
}
