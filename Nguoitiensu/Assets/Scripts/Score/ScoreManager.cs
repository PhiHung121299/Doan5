using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
   public static ScoreManager instance;
    public TextMeshProUGUI text1,text2,text3;
 
    int score;
    int meet;
    int health;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int itemValue)
    {
        score += itemValue;
        text1.text = "X" + score.ToString();
    }
    public void ChangeMeet(int itemValue)
    {
        meet += itemValue;
        text3.text = "X" + meet.ToString();
    }
    public void Health_number(int healthPlayer)
    {
        health = healthPlayer;
        text2.text=health.ToString() + "/100";
    }
}
