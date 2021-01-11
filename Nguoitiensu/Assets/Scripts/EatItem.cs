using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : MonoBehaviour
{
    public Rigidbody2D r2;
    // Start is called before the first frame update
    void Start()
    {
        r2.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("item_eat")){
            Destroy(collision.gameObject);
        }
    }
}
