using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Loading_Scene : MonoBehaviour
{
    //Variables
    public float loadingTime;
    public Image loadingBar;
    public Text percent;


    //Methodes
    void Start()
    {
        loadingBar.fillAmount = 0;
    }

    void Update()
    {
        if (loadingBar.fillAmount <= 1)
        {
            loadingBar.fillAmount += 1f / loadingTime * Time.deltaTime;
        }

        if (loadingBar.fillAmount == 1f)
        {
            Application.LoadLevel(1);
        }
        percent.text = (loadingBar.fillAmount * 100).ToString("0");
    }
}
