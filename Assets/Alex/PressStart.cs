using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//I HAVE NP PLUS A BAZILLION ESSAYS TO WRITE WHY DID I SIGN UP FOR THIS. Also this code is made by Alexander and is an incredibly basic main menu code.

public class PressStart : MonoBehaviour
{
    [SerializeField]
    public AudioSource bgMusic;
    [SerializeField]
    public AudioSource cancelSE;
    [SerializeField]
    public KeyCode enter;
    [SerializeField]
    public KeyCode back;
    [SerializeField]
    public KeyCode up;
    [SerializeField]
    public KeyCode down;
    [SerializeField]
    public KeyCode left;
    [SerializeField]
    public KeyCode right;
    [SerializeField]
    public Vector3[] positions;
    [SerializeField]
    int currentPos;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = 0;
        timer = 0;
        bgMusic.Play();
    }

    // Update is called once per frame
    void Update()   
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentPos], Time.deltaTime * 10);
        timer += Time.deltaTime;
        if (Input.GetKey(up) && currentPos == 0)
        {
            currentPos = 1;
            timer = 0;

        }
        else if (Input.GetKey(down) && currentPos == 0)
        {
            currentPos = 3;
            timer = 0;
        }
        if (Input.GetKey(up) && timer > 0.15f)
        {
            if(currentPos == 1)
            {
                currentPos= 3;
            }
            else
            {
                currentPos += -1;
            }
            timer = 0;

        }
        else if (Input.GetKey(down) && timer > 0.15f)
        {
            if (currentPos == 3)
            {
                currentPos = 1;
            }
            else
            {
                currentPos++;
            }
            timer = 0;
        }

        if (Input.GetKey(enter))
        {
            if (currentPos == 1)
            {
                SceneManager.LoadScene(1);
            }
            else if(currentPos == 2 && timer > 0.15f)
            {
                cancelSE.Play();
                timer = 0;
            }
            else if(currentPos == 3)
            {
                Application.Quit();
            }
        }
    }
}
