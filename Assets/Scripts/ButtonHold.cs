using HurricaneVR.Framework.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonHold : MonoBehaviour
{
    [SerializeField] public UnityEvent ButtonOnHold = new UnityEvent();

    [SerializeField] GameObject ui;
    [SerializeField] Image fillImage;
    [SerializeField] HVRPhysicsButton physicButton;
    [SerializeField] float holdTime;

    private bool isPressing;
    private float holdCounter;
    private bool wasTrigger;

    private void Start()
    {
        physicButton.ButtonDown.AddListener(OnButtonDown);
        physicButton.ButtonUp.AddListener(OnButtonUp);
    }

    private void OnButtonUp(HVRPhysicsButton arg0)
    {
        ui.SetActive(false);
        isPressing = false;
        holdCounter = 0;
    }

    private void OnButtonDown(HVRPhysicsButton arg0)
    {
        if (wasTrigger)
            return;

        ui.SetActive(true);
        fillImage.fillAmount = 0;
        isPressing = true;
    }

    private void Update()
    {
        if (isPressing)
        {
            holdCounter += Time.deltaTime;

            fillImage.fillAmount = holdCounter / holdTime;

            if (holdCounter > holdTime)
            {
                wasTrigger = true;
                ui.SetActive(false);
                ButtonOnHold?.Invoke();
            }
        }
    }

    private void OnDisable()
    {
        physicButton.ButtonDown.RemoveAllListeners();
        physicButton.ButtonUp.RemoveAllListeners();
    }
}
