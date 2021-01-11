using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
  
   public int health;
    public static HealthBarScript instance;
    [SerializeField] Sprite health0;
    [SerializeField] Sprite health1;
    [SerializeField] Sprite health2;
    [SerializeField] Sprite health3;
    [SerializeField] Sprite health4;
    [SerializeField] Sprite health5;
    [SerializeField] Sprite health6;
    [SerializeField] Sprite health7;
    [SerializeField] Sprite health8;
    [SerializeField] Sprite health9;
    [SerializeField] Sprite health10;
    private SpriteRenderer changeSprite;
    // Start is called before the first frame update
    void Start()
    {
        changeSprite = GetComponent<SpriteRenderer>();

        if (instance == null)
        {
            instance = this;
        }
    }
    public void Mau(int HealthPlayer) {
        health = HealthPlayer;
        if (health == 100)
        {
            changeSprite.sprite = health0;
        }
        if (health == 90)
        {
            changeSprite.sprite = health1;
        }
        if (health == 80)
        {
            changeSprite.sprite = health2;
        }
        if (health == 70)
        {
            changeSprite.sprite = health3;
        }
        if (health == 60)
        {
            changeSprite.sprite = health4;
        }
        if (health == 50)
        {
            changeSprite.sprite = health5;
        }
        if (health == 40)
        {
            changeSprite.sprite = health6;
        }
        if (health == 30)
        {
            changeSprite.sprite = health7;
        }
        if (health == 20)
        {
            changeSprite.sprite = health8;
        }
        if (health == 10)
        {
            changeSprite.sprite = health9;
        }
        if (health == 10)
        {
            changeSprite.sprite = health10;
        }
    }
}
