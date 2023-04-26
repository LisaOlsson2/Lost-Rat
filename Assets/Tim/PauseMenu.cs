using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public readonly float timescale = 1.4f;
    public GameObject InGameMenu;
    public GameObject pauseButton;
    private bool Paused;
    // Update is called once per frame
    private void Start()
    {
        InGameMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == false)
            {
                StartPause();
            }
            else
            {
                UnPause();
            }
        }
    }
    public void StartPause()
    {
        pauseButton.SetActive(false);
        InGameMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
    public void UnPause()
    {
        pauseButton.SetActive(true);
        InGameMenu.SetActive(false);
        Time.timeScale = timescale;
        Paused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}
