using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_item : MonoBehaviour
{
    public  int itemValue=1;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(itemValue);
        }
    }

}
