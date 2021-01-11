using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float kill1Delay = 0.3f;
    public bool kill1 = false;
    public Animator anim;
    public Collider2D trigger;
    public SoundManager sound;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

        trigger.enabled = false;
    }

    private void Start()
    {
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        int dame = 20;
        if (Input.GetKeyDown(KeyCode.Z) && !kill1)
        {
            kill1 = true;
            trigger.enabled = true;
            kill1Delay = 0.3f;
            sound.Playsound("kill1");
        }
        if (kill1)
        {
            if (kill1Delay > 0)
            {
                kill1Delay -= Time.deltaTime;

            }
            else
            {
                kill1 = false;
                trigger.enabled = false;

            }
          
        }
        anim.SetBool("Kill1", kill1);

    }
  

 
}
