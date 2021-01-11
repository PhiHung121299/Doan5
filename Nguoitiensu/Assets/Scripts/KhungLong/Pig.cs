using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit;

    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;

    public static bool isAttacking = false;


    private void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();

    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position,target.position );
        if (distance>attackDistance) {

            //Move();
            StopAttack();

        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();

        }
        if (cooling) {
            Cooldown();
            anim.SetBool("Attack", false);
                }
    }
    void Move()
    {
        anim.SetBool("canWalk",true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))

        {
            Vector2 tagetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, tagetPosition, moveSpeed * Time.deltaTime);
        }
    }
    
  
    void Cooldown()
    {
        timer -= Time.deltaTime;
        if (timer<=0 &&cooling &&attackMode) {
            cooling = false;
            timer = intTimer;
        }
    }
   public void Attack()
    {
        SelectTaget();
        timer = intTimer;
        attackMode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    } 
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }
        if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            SelectTaget();
        }
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
            RaycastDebugger();
        }
        if (hit.collider != null)
        {
            EnemyLogic();
        } else if (hit.collider == null)
        {
            //anim.SetBool("canWalk", false);
            StopAttack();
        }


    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;

            Flip();
        }
 
      
    }
    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);

        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position,transform.right * rayCastLength, Color.green);

        }

    }
    public void TriggerColing()
    {
        cooling = true;
    }
    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }
    private void SelectTaget()
    {
        float distanceToleft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToright = Vector2.Distance(transform.position, rightLimit.position);
        if (distanceToleft > distanceToright)
        {
            target = leftLimit;
        }
        else {
            target = rightLimit;
        }
    }
    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
}
