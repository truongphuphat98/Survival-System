using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replenish : MonoBehaviour
{
    //Variables
    [Header("Replenish Items")]
    public string replenishItemName;
    [SerializeField] private bool replenishHealth;
    [SerializeField] private bool replenishHunger;
    [SerializeField] private bool replenishThirst;
    [SerializeField] private float value;

    [SerializeField] private Player_HUD_Systems _PlayerHUD;

    //Methodes
    public void Interaction()
    {
        if (replenishHunger)
        {
            _PlayerHUD.hungerSlider.value += value;
        }

        else if (replenishThirst)
        {
            _PlayerHUD.thirstSlider.value += value;
        }

        else if (replenishHealth)
        {
            _PlayerHUD.healthSlider.value += value;
        }
    }
}
