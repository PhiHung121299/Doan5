using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuoiThu : MonoBehaviour
{
    public Animator anim;
    public float speed = 40f, maxspeed = 5, jumpow = 370f;
    public bool thucuoi = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C) && !thucuoi)
        {
            thucuoi = true;
            maxspeed = 10;
            anim.SetBool("CuoiThu", thucuoi);

        }
        if (Input.GetKeyDown(KeyCode.V) && thucuoi)
        {
            maxspeed = 5;
            thucuoi = false;
            anim.SetBool("CuoiThu", thucuoi);
        }
    } 
}
