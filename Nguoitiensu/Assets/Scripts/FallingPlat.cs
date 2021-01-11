using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    public Rigidbody2D r2d;
    public float timedelay=1 ;

    // Start is called before the first frame update
    void Start()
    {
        r2d = gameObject.GetComponent<Rigidbody2D>();
    }

    //khi một collider va chạm với một collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }
    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay);
        r2d.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
