using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhungLong_hanhdong : MonoBehaviour
{
    public Transform KhungLongGai;
    public LayerMask KLGmask;
    public float KLGlength;
    public float attackDistance;
    public float movespeed;
    public float timer;

    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackmode;
    private bool inRange;
    private bool cooling;
    private float intTimer;

    private void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(KhungLongGai.position, Vector2.left, KLGlength,KLGmask);
            RaycastDebugger();
        }
        if (hit.collider!=null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (inRange==false) {
            anim.SetBool("canWalk", false);
                StopAttack(); }
    }
    void EnemyLogic() {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance>attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance>=distance&&cooling==false)
        {
            Attack();

        }
        if (cooling) {
            CoolDown();
            anim.SetBool("Attack", false);
        }
    }
   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player" ) {
            target = collision.gameObject;
            inRange = true;

        }
    }
    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movespeed*Time.deltaTime);
        }
    }
    void CoolDown()
    {
        timer -= Time.deltaTime;
        if (timer<=0 &&cooling&&attackmode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    void Attack() 
    {
        timer = intTimer;
        attackmode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }
    void StopAttack()
    {
        cooling = false;
        attackmode = false;
        anim.SetBool("Attack", false);

    }
    void RaycastDebugger()
    {
        if (distance>attackDistance)
        {
            Debug.DrawRay(KhungLongGai.position, Vector2.left * KLGlength, Color.red);
        }
        else    if(attackDistance>distance)
        {
            Debug.DrawRay(KhungLongGai.position, Vector2.left * KLGlength, Color.green);
        }
    }
    public void TriggerCooling()
    {
        cooling = true;
    }
}
