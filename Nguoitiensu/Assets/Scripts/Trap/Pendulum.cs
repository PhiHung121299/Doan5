using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    static Rigidbody2D bd2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;
    // Start is called before the first frame update
    void Start()
    {
        bd2d = GetComponent<Rigidbody2D>();
        bd2d.angularVelocity = velocityThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }
    public void Push()
    {
        if (transform.rotation.z > 0 && transform.rotation.z<rightPushRange
            &&(bd2d.angularVelocity>0)&&bd2d.angularVelocity<velocityThreshold)
        {
            bd2d.angularVelocity = velocityThreshold;

        }else if(transform.rotation.z < 0 && transform.rotation.z > leftPushRange
            && (bd2d.angularVelocity < 0) && bd2d.angularVelocity > velocityThreshold*-1)
        {
            bd2d.angularVelocity = velocityThreshold * -1;
        }
    }
}
