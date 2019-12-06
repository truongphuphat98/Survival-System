using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    //Variables
    private GameObject raycastObj;

    [Header("Raycast Settings")]
    [SerializeField] private float rayLength = 10;
    [SerializeField] private LayerMask newLayerMask;

    [Header("References")]
    [SerializeField] private Player_HUD_Systems _PlayerHUD;
    [SerializeField] private Image crossHair;
    [SerializeField] private Text itemNameText;

    //Methodes
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, forward, out hit, rayLength, newLayerMask.value))
        {
            if(hit.collider.CompareTag("Consumable"))
            {
                CrosshairActive();
                raycastObj = hit.collider.gameObject;
                //raycastObj.GetComponent<MeshRenderer>().material.shader = Shader.Find("Stencil/Outline");
                itemNameText.text = raycastObj.GetComponent<Consumable>().consumableName;

                if (Input.GetMouseButton(0))
                {
                    raycastObj.GetComponent<Consumable>().Interaction();
                    raycastObj.SetActive(false);
                }
            }

            if (hit.collider.CompareTag("Useable"))
            {
                CrosshairActive();
                raycastObj = hit.collider.gameObject;
                itemNameText.text = raycastObj.GetComponent<Useable>().itemName;

                if (Input.GetKey(KeyCode.E))
                {
                    raycastObj.GetComponent<Useable>().Interaction();
                    Debug.Log("Interacting with Object!");
                }
            }

            if (hit.collider.CompareTag("Replenish"))
            {
                CrosshairActive();
                raycastObj = hit.collider.gameObject;
                itemNameText.text = raycastObj.GetComponent<Replenish>().replenishItemName;

                if (Input.GetMouseButton(0))
                {
                    raycastObj.GetComponent<Replenish>().Interaction();
                }
            }
        }

        else
        {
            CrosshairNormal();
            itemNameText.text = null;
        }
    }

    void CrosshairActive()
    {
        crossHair.color = Color.green;
    }

    void CrosshairNormal()
    {
        crossHair.color = Color.black;
    }
}
