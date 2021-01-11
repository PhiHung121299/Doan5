using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.isTrigger==false)
        player.grounded = true; 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false||collision.CompareTag("wanter"))
            player.grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("wanter"))
            player.grounded = false;   
    }
   
}
