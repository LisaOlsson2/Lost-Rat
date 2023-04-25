using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    readonly float timescale = 1.4f;
    public GameObject InGameMenu;
    // Update is called once per frame
    public void StartPause()
    {
        InGameMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        InGameMenu.SetActive(false);
        Time.timeScale = timescale;
    }

}
