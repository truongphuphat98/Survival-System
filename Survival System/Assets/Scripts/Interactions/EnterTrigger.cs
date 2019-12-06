using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    private Player_HUD_Systems _playerHUD;

    [SerializeField] private bool triggeringFireplace;
    [Tooltip("0.1 is by Default")]
    [SerializeField] private float poisonDamageValue;
    [SerializeField] private float healUpValue;

    void Start()
    {
        _playerHUD = GetComponent<Player_HUD_Systems>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fireplace")
        {
            triggeringFireplace = true;
            Debug.Log("EnterTrigger");
        }

        if (other.tag == "Poison")
        {
            _playerHUD.healthSlider.value -= poisonDamageValue * Time.deltaTime;
            Debug.Log("Get Poison");
        }

        if (other.tag == "Heal")
        {
            _playerHUD.healthSlider.value += healUpValue * Time.deltaTime;
            Debug.Log("Get Heal");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fireplace")
        {
            triggeringFireplace = true;
            Debug.Log("StayTrigger");
        }

        if (other.tag == "Poison")
        {
            _playerHUD.healthSlider.value -= poisonDamageValue * Time.deltaTime;
            Debug.Log("Get Poison");
        }

        if (other.tag == "Heal")
        {
            _playerHUD.healthSlider.value += healUpValue * Time.deltaTime;
            Debug.Log("Get Heal");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fireplace")
        {
            triggeringFireplace = false;
            Debug.Log("ExitTrigger");
        }

        if (other.tag == "Poison")
        {
            Debug.Log("No Longer Poison");
        }

        if (other.tag == "Heal")
        {
            Debug.Log("No longer Being Heal");
        }
    }
}
