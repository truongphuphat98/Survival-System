using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    //Variables
    [Header("Consumable Items")]
    public string consumableName;
    [SerializeField] private bool food;
    [SerializeField] private bool water;
    [SerializeField] private bool medicine;
    [SerializeField] private float value;

    [SerializeField] private Player_HUD_Systems _PlayerHUD;

    //Methodes
    public void Interaction()
    {
        if (food)
        {
            _PlayerHUD.hungerSlider.value += value;
        }

        else if (water)
        {
            _PlayerHUD.thirstSlider.value += value;
        }

        else if (medicine)
        {
            _PlayerHUD.healthSlider.value += value;
        }
    }
}
