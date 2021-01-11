using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int dame = 20;

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true&&collision.tag == "Player")
        {

            collision.SendMessageUpwards("_Damage", dame);
            Pig.isAttacking = true;

        }
    }
}
