using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemTest : MonoBehaviour
{
    void Start()
    {
        
        //Language, Country, Date
        Debug.Log(Application.systemLanguage);
        Debug.Log(System.Globalization.RegionInfo.CurrentRegion);
        Debug.Log(System.DateTime.Today.ToString("dd/MM/yyyy"));

        //Normal, Warning & Error Log
        Debug.Log("This is an info log");
        Debug.LogWarning("This is a warn log");
        Debug.LogError("This is an error log");

        //This GameObject
        Debug.Log("Debug on this gameobject", this.gameObject);
        Debug.Log("Hello: " + gameObject.name);
        

        //Current Time
        Debug.Log(System.DateTime.Now);
        Debug.Log(System.Globalization.CultureInfo.CurrentCulture);

    }
}
