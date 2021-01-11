using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dame = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        //{
        //    collision.SendMessageUpwards("_Damage", 1);

        //}
        var enemy = collision.GetComponent<Enemy_behaviour>();
        if (enemy)
        {
            enemy.TakeHit(1);
        }
    }
}
