using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PressStart : MonoBehaviour
{
    [SerializeField]
    public TMP_Text startText;
    bool startIsUp;
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
    public static KeyCode enterParsed;
    public static KeyCode backParsed;
    public static KeyCode upParsed;
    public static KeyCode downParsed;
    public static KeyCode leftParsed;
    public static KeyCode rightParsed;

    // Start is called before the first frame update
    void Start()
    {
        startText = this.GetComponent<TMP_Text>();
        startIsUp = true;
        enterParsed = enter;
        backParsed = back;
        upParsed = up;
        downParsed = down;
        leftParsed = left;
        rightParsed = right;
    }

    // Update is called once per frame
    void Update()   
    {
        startText.text = "- Press " + enterParsed + " to Start -";
        if (startIsUp)
        {
            FadeIn();
        }
        else if(!startIsUp)
        {
            FadeOut();
        }
        if(Input.GetKey(enter))
        {
            startIsUp = false;
        }
        else if(Input.GetKey(backParsed))
        {
            startIsUp = true;
        }
    }

    void FadeOut()
    {
        startText.CrossFadeAlpha(0, 20 * Time.deltaTime, true);
    }

    void FadeIn()
    {
        startText.CrossFadeAlpha(1, 30 * Time.deltaTime, true);
    }
}
