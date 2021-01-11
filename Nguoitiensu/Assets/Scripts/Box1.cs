using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box1 : MonoBehaviour
{
    public int health = 100;
    
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
         
    }
    void _Damage(int dame)
    {
        health -= dame;

    }
    }
