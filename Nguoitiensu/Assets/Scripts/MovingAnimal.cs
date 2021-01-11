 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingAnimal : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;
    public Rigidbody2D MyRigidbody;
    public Collider2D trigger;

    public bool isFacingRight;
 
    void Start()
    {
        MyRigidbody = gameObject.GetComponent<Rigidbody2D>();
        trigger.enabled = true;
    }


    void Update()
    {
        if (IsFacingRight())
        {
            MyRigidbody.velocity = new Vector2(moveSpeed, 0f);

        }
        else
        {
            MyRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }

    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
     
            transform.localScale = new Vector2(-(Mathf.Sign(MyRigidbody.velocity.x)), transform.localScale.y);
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);  
        }

    }
}
