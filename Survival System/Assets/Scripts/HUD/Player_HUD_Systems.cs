using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine;

public class Player_HUD_Systems : MonoBehaviour
{
    //Variables
    [Header("Health Settings")]
    public Slider healthSlider;
    public int maxHealth;
    public int healthDecreaseRate;

    [Header("Thirst Settings")]
    public Slider thirstSlider;
    public int maxThirst;
    public int thirstDecreaseRate;

    [Header("Hunger Settings")]
    public Slider hungerSlider;
    public int maxHunger;
    public int hungerDecreaseRate;

    [Header("Stamina Settings")]
    public Slider staminaSlider;
    public int maxStamina;
    private int staminaDecreaseRate;
    public int staminaDecreaseMultiply; //how fast it decrease
    private int staminaRegainRate;
    public int staminaRegainMultiply;

    [Header("Temperature Settings")]
    public float freezing_Temperature;
    public float current_Temperature;
    public float normal_Temperature;
    public float heat_Temperature;
    public Text temperature_Number;
    public Image temperature_BG;

    [Header("Coldness Settings")]
    public float maxColdness;
    public float coldness;

    [Header("Trigger Settings")]
    [SerializeField] private bool triggeringFireplace;
    [Tooltip("0.1 is by Default")]
    public float poisonDamageValue;
    public float healUpValue;

    private CharacterController char_Controller;
    private FirstPersonController fp_Controller;
    private EnterTrigger _fireplaceTrigger;

    //Methodes
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        thirstSlider.maxValue = maxThirst;
        thirstSlider.value = maxThirst;

        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = maxHunger;

        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;

        staminaDecreaseRate = 1;
        staminaRegainRate = 1;

        char_Controller = GetComponent<CharacterController>();
        fp_Controller = GetComponent<FirstPersonController>();

    }

    void UpdateTemperature()
    {
        temperature_Number.text = current_Temperature.ToString("00.0");
    }

    void Update()
    {
        //Temperature
        if (current_Temperature <= freezing_Temperature)
        {
            temperature_BG.color = Color.blue;
            UpdateTemperature();
        }
        else if (current_Temperature >= heat_Temperature - 0.1)
        {
            temperature_BG.color = Color.red;
            UpdateTemperature();
        }
        else
        {
            temperature_BG.color = Color.green;
            UpdateTemperature();
        }

        //Temperature_Coldness
        if (triggeringFireplace && coldness > 0)
        {
            coldness -= 1 * Time.deltaTime;
        }
        //0
        else if (coldness <= 0)
        {
            coldness = 0;
        }

        //
        if (triggeringFireplace == false)
        {
            coldness += 1 * Time.deltaTime;
        }
        else if (coldness >= maxColdness)
        {
            coldness = maxColdness = 10;
        }

        //Health
        if (hungerSlider.value <= 0 && (thirstSlider.value <= 0))
        {
            healthSlider.value -= Time.deltaTime / healthDecreaseRate * 2;
        }
        else if (hungerSlider.value <= 0 || thirstSlider.value <= 0 || current_Temperature <= freezing_Temperature || current_Temperature >= heat_Temperature)
        {
            healthSlider.value -= Time.deltaTime / healthDecreaseRate;
        }

        if(healthSlider.value <= 2)
        {
            Debug.Log("Almost Die");
        }

        if (healthSlider.value <= 0)
        {
            Character_Death();
        }


        //Hunger
        if (hungerSlider.value >= 0)
        {
            hungerSlider.value -= Time.deltaTime / hungerDecreaseRate;
        }
        else if (hungerSlider.value <= 0)
        {
            hungerSlider.value = 0;
        }
        else if (hungerSlider.value >= maxHunger)
        {
            hungerSlider.value = maxHunger;
        }

        //Thirst
        if (thirstSlider.value >= 0)
        {
            thirstSlider.value -= Time.deltaTime / thirstDecreaseRate;
        }
        else if (thirstSlider.value <= 0)
        {
            thirstSlider.value = 0;
        }
        else if (thirstSlider.value >= maxThirst)
        {
            thirstSlider.value = maxThirst;
        }

        //Stamina
        if (char_Controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            staminaSlider.value -= Time.deltaTime / staminaDecreaseRate * staminaDecreaseMultiply;

            if (staminaSlider.value > 0)
            {
                current_Temperature += Time.deltaTime / 5;
            }
        }
        else
        {
            staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMultiply;

            current_Temperature -= Time.deltaTime / 10;
        }

        if (staminaSlider.value >= maxStamina)
        {
            staminaSlider.value = maxStamina;
        }
        else if (staminaSlider.value <= 0)
        {
            staminaSlider.value = 0;
            fp_Controller.m_RunSpeed = fp_Controller.m_WalkSpeed;
        }

        else if (staminaSlider.value >= 0)
        {
            fp_Controller.m_RunSpeed = fp_Controller.m_RunSpeedRegular;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fireplace")
        {
            triggeringFireplace = true;
            coldness -= 1 * Time.deltaTime;
            
            Debug.Log("EnterTrigger");
        }

        if (other.tag == "Poison")
        {
            healthSlider.value -= poisonDamageValue * Time.deltaTime;
            Debug.Log("Get Poison");
        }

        if (other.tag == "Heal")
        {
            healthSlider.value += healUpValue * Time.deltaTime;
            Debug.Log("Get Heal");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fireplace")
        {
            triggeringFireplace = true;
            coldness -= 1 * Time.deltaTime;
            Debug.Log("StayTrigger");
        }

        if (other.tag == "Poison")
        {
            healthSlider.value -= poisonDamageValue * Time.deltaTime;
            Debug.Log("Get Poison");
        }

        if (other.tag == "Heal")
        {
            healthSlider.value += healUpValue * Time.deltaTime;
            Debug.Log("Get Heal");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fireplace")
        {
            triggeringFireplace = false;
            coldness += 1 * Time.deltaTime;
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

    void Character_Death()
    {
        print("You've Died");
    }
}
