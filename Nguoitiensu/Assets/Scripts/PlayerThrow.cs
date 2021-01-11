using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public float kill2Delay = 0.3f;
    public bool kill2 = false;
    public Animator anim;
    public Collider2D trigger;
    public SoundManager sound;
    private void Start()
    {
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

        trigger.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !kill2)
        {
            kill2 = true;
            trigger.enabled = true;
            kill2Delay = 0.3f;
            sound.Playsound("kill2");
        }
        if (kill2)
        {
            if (kill2Delay > 0)
            {
                kill2Delay -= Time.deltaTime;

            }
            else
            {
                kill2 = false;
                trigger.enabled = false;

            }
            
        }
        anim.SetBool("Kill2", kill2);

    }
 
}
