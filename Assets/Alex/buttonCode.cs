using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class buttonCode : MonoBehaviour
{
    [SerializeField]
    private int buttonID;
    [SerializeField]
    private AudioSource cancelSE;
    Button clickButton;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        clickButton = GetComponent<Button>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void onClick()
    {
        if (buttonID == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if (buttonID == 2 && timer > 0.15f)
        {

            {
                cancelSE.Play();
                timer = 0;
            }
        }
        else if(buttonID == 3)
        {
            Application.Quit();
        }
    }
}
