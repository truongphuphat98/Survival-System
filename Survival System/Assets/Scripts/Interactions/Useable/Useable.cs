using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Useable : MonoBehaviour
{
    [Header("Useable Items")]
    public string itemName;

    [Header("Sleeping")]
    [SerializeField] private bool bed;

    [SerializeField] private Player_HUD_Systems _PlayerHUD;

    public void Interaction()
    {
        
    }
}
