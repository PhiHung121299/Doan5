using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameover;
    private bool over = false;
    public int health;
    public static GameOver instance;
    private void Start()
    {
   

        if (instance == null)
        {
            instance = this;
        }
        gameover.SetActive(false);
    }

    public void TiepTuc(int HealthPlayer)
    {
        health = HealthPlayer;
        if (health == 0)
        {
            over = true;
            gameover.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
