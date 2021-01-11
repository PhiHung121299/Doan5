using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amthanh : MonoBehaviour
{
    public SoundManager sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sound.Playsound("voi");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sound.StopCoroutine("voi");

        }
    }
    
}
