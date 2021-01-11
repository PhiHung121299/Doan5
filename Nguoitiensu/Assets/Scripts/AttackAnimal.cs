using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimal : MonoBehaviour
{
    public int dame = 15;
    public Pig pig;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Player"))
        {

            collision.SendMessageUpwards("_Damage", dame);
                Pig.isAttacking = true;
     
        }
      

    }
}
