using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PausedMenu : MonoBehaviour {

    public GameObject pauseUI;
    private bool isPaused = false;

	void Start () {
        pauseUI.SetActive(false);
	}
	
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
	}

    public void Resume()
    {
        isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void ToMainMenu()
    {
        Application.Quit(); //Later load to Main Menu -> make main menu have an exit condition
    }
}
