using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    public float speed = 40f, maxspeed = 5, jumpow = 370f;
    public Rigidbody2D r2;
    public Animator anim;
    public bool faceright = true; 
    public bool grounded = true, DoubleJump=false ,death=false, hit=false;
    Transform child;
    public int healthPlayer = 100;
    public SoundManager sound;
    public bool CuoiThu = false;
    //
    public GameObject gameover;

    //
    public GameObject Nhiemvu;
    private bool nv = false;
  
    public int itemValue = 1, meet=1;

    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        child = gameObject.transform.GetChild(0);
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        Nhiemvu.SetActive(false);
        gameover.SetActive(false);
    }
    void Update()
    {
        
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                DoubleJump = true;
                sound.Playsound("jump");
                r2.AddForce(Vector2.up * jumpow);
            }
            else
            {
                if (DoubleJump)
                {
                    DoubleJump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpow * 0.7f);
                    sound.Playsound("jump");
                }
            }
           
        }
  
   
        if (nv)
        {
            Nhiemvu.SetActive(true);
            Time.timeScale = 0f;

        }

    }
       
    void FixedUpdate()
    {

      ScoreManager.instance.Health_number(healthPlayer);
     HealthBarScript.instance.Mau(healthPlayer);
      
        if (healthPlayer == 0)
        {
            death = true;
            anim.SetBool("death", death);
            Debug.Log("Death");
          
            Death();
        }

  
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        if (r2.velocity.x > maxspeed)
        {
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        }
        if (r2.velocity.x < -maxspeed)
        {
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        }
        if (h>0 &&!faceright) {
            Flip();
        }
        if(h<0&& faceright)
        {
            Flip();
        }
        //tạo ma sát
        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.9f,r2.velocity.y);

        }
        
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovingGround")) {
            this.transform.parent = collision.transform;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (this.gameObject.activeSelf == true) this.transform.parent = null;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "HitBox"||collision.CompareTag("trap"))
        {
            float scaleX =child.localScale.x;
            scaleX -= 0.1f;
            if (healthPlayer<=0) {
                healthPlayer = 0;
    

            }
            if (scaleX <= 0f)
            {
                scaleX = 0;
                Debug.Log("Game Over");

            }
            child.localScale = new Vector3(scaleX, child.localScale.y, child.localScale.z);


        }
        if (collision.gameObject.tag == "health")
        {
            float scaleX = child.localScale.x;
            scaleX += 0.2f;
            healthPlayer = healthPlayer + 20;
            if (healthPlayer > 100)
            {
                healthPlayer = 100;
            }
            Destroy(collision.gameObject);
            sound.Playsound("eat");
            if (scaleX >= 1f)
            {
                scaleX = 1;
                Debug.Log("Max Health");

            }
            child.localScale = new Vector3(scaleX, child.localScale.y, child.localScale.z);


        }
        // an iteam 
        if (collision.CompareTag("item_eat"))
        {
         
            Destroy(collision.gameObject);
            sound.Playsound("eat");
        }
        //bi quai danh
        if (collision.CompareTag("trap")|| collision.CompareTag("HitBox"))
        {
            hit = true;
            anim.SetBool("hit", hit);
         
        }
        //chet
        if (collision.CompareTag("Death")|| collision.CompareTag("bayho"))
        {
             Invoke("Death", 2);
          //  healthPlayer = 0;
          //  GameOver.instance.TiepTuc(0);
            anim.SetBool("death",true);
            
            float scaleX = child.localScale.x;
            scaleX = 0;
            Debug.Log("Game Over");
            child.localScale = new Vector3(scaleX, child.localScale.y, child.localScale.z);
           
            //Death();
        }
        if (collision.gameObject.CompareTag("Egg")){

            Debug.Log("Thu thập trứng");
            Destroy(collision.gameObject);
        }
        // meet eat
        if (collision.CompareTag("health"))
        {
            ScoreManager.instance.ChangeMeet(meet);
        }
        if (collision.CompareTag("item_eat"))
        {
            ScoreManager.instance.ChangeScore(itemValue);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("trap")||collision.CompareTag("HitBox"))
        {
            hit = false;
            anim.SetBool("hit", hit);
        }
        if (collision.CompareTag("Egg"))
        {
            nv = !nv;
            
        }
    }
    public void Death()
    {
        healthPlayer = 0;
        gameover.SetActive(true);
        Time.timeScale = 0f;
       

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void _Damage(int dame)
    {
        healthPlayer -= dame;

    }
    public void Skip()
    {
        nv = false;
        Nhiemvu.SetActive(false);
        Time.timeScale = 1;
    }

}
