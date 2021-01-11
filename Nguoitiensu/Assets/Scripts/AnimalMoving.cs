using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoving : MonoBehaviour
{
    public float walkspeed;
    [HideInInspector]
    [SerializeField] float moveSpeed = 1f;
    private bool mustTurn;
    public bool mustPatrol;
    public Rigidbody2D r2d;
    public Transform goundCheckpos;
    public Collider2D bodyColider;
    public LayerMask groundeLayer;


  void Start()
    {
        mustPatrol = true;
    }
   void Update()
    {
        if (mustPatrol)
        {
            Patrol(); 
        }
        
    }
  private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(goundCheckpos.position, 0.1f,groundeLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn || bodyColider.IsTouchingLayers(groundeLayer))
        {
            //Flip();
            if (IsFacingRight())
            {
                r2d.velocity = new Vector2(moveSpeed, 0f);

            }
            else
            {
                r2d.velocity = new Vector2(-moveSpeed, 0f);
            }

        }


    
        r2d.velocity = new Vector2(walkspeed * Time.fixedDeltaTime, r2d.velocity.y);
    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    //void Flip()
    //{
    //    mustPatrol = false;

    //    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    //    walkspeed *=  -1;

    //    mustPatrol = true;
    //}
}
