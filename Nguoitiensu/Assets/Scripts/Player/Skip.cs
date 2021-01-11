using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    public GameObject ChuGiai;
    private bool cg = false;
   
    public void TiepTuc()
    {
        cg = false;
        ChuGiai.SetActive(false);
        Time.timeScale = 1;
    }
}
