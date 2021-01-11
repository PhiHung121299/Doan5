using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGound : MonoBehaviour
{
    public float freq = 0.5f;
    public float amp = 4f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    void Start()
    {
        posOffset = transform.position;
    }
    void Update()
    {
        tempPos = posOffset;
        transform.position = new Vector3(transform.position.x, tempPos.y + Mathf.Sin(Time.fixedTime * Mathf.PI * freq) * amp, transform.position.z);
    }
 
}
