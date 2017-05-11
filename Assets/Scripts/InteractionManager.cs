using DigitalRuby.LightningBolt;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractionManager : MonoBehaviour {

    public GameObject effectObject;
    public Transform body;

    private GameObject effect;

    private GameObject leftController;
    private GameObject rightController;

    private VRTK_ControllerEvents leftControllerEvents;
    private VRTK_ControllerEvents rightControllerEvents;

    void Awake()
    {
        InitializeControllers();

        effect = Instantiate(effectObject, body);
        effect.SetActive(false);
    }

    void Update()
    {
        bool gripsHeld = leftControllerEvents.gripPressed && rightControllerEvents.gripPressed;

        if (gripsHeld && !effect.activeSelf)
        {
            effect.SetActive(true);
        }
        else if (!gripsHeld && effect.activeSelf)
        {
            effect.SetActive(false);
        }
    }

    void InitializeControllers()
    {
        leftController = VRTK_DeviceFinder.GetControllerLeftHand();
        rightController = VRTK_DeviceFinder.GetControllerRightHand();
        leftControllerEvents = leftController.GetComponent<VRTK_ControllerEvents>();
        rightControllerEvents = rightController.GetComponent<VRTK_ControllerEvents>();
    }
}
