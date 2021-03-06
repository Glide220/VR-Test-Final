using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl2 : MonoBehaviour
{
    
    private bool on = false;
    private bool buttonHit = false;
    private GameObject button;

    private float buttonDownDistance = 0.025f;
    private float buttonReturnSpeed = 0.001f;
    private float buttonOriginalY;

    public GameObject ui;

    private float buttonHitAgainTime = 0.5f;
    private float canHitAgain;
    void Start()
    {
        button = transform.GetChild(0).gameObject;
        buttonOriginalY = button.transform.position.y;

        ui.SetActive(false);
    }

    
    void Update()
    {
        if(buttonHit == true)
        {
        //    if(ui.activeInHierarchy == false)
        //    {
        //       ui.SetActive(true);
        //    } else 
        //    {
        //        ui.SetActive(false);
        //    }
        //}

            buttonHit = false;

            on = !on;

            button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - buttonDownDistance, button.transform.position.z);

            if(on)
            {
                ui.SetActive(true);
            }else
            {
                ui.SetActive(false);
            }
        }

        if (button.transform.position.y < buttonOriginalY)
        {
            button.transform.position += new Vector3(0, buttonReturnSpeed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand") && canHitAgain < Time.time)
        {
            canHitAgain = Time.time + buttonHitAgainTime;
            buttonHit = true;
        }
    }
}
