using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUse : MonoBehaviour


{
    public GameObject pauseUI;
    private bool pause = false;

    void Start()
    {
        pauseUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;

        }
        if (pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0f;

        }
        if (pause==false) {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }

       
    }
    public void renume()
    {
        pause = false;
    }
    public void restar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        // Application.Quit();
    }
}
