using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    //Variables
    public Text gameTimer_Text;
    float gameTimer = 0f;

    //Methodes
    void Start()
    {

    }

    void Update()
    {
        gameTimer += Time.deltaTime;

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24;

        string timer_String = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        gameTimer_Text.text = timer_String;
    }


}
