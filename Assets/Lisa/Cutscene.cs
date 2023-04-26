using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    readonly float duration = 4;

    [SerializeField]
    GameObject[] frames;

    float timer;
    int frame;

    void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            frame++;
            if (frame < frames.Length)
            {
                frames[frame - 1].SetActive(false);
                frames[frame].SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Game Scene");
            }
        }
    }
}
