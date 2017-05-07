using DigitalRuby.LightningBolt;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractionManager : MonoBehaviour {

    public GameObject lightningPrefab;

    private LightningBoltScript lightningScript;
    private GameObject leftController;
    private GameObject rightController;
    private VRTK_ControllerEvents leftControllerEvents;
    private VRTK_ControllerEvents rightControllerEvents;

    void Awake()
    {
        leftController = VRTK_DeviceFinder.GetControllerLeftHand();
        rightController = VRTK_DeviceFinder.GetControllerRightHand();
        leftControllerEvents = leftController.GetComponent<VRTK_ControllerEvents>();
        rightControllerEvents = rightController.GetComponent<VRTK_ControllerEvents>();

        InstantiateLightning();
    }

    void Update()
    {
        if(leftControllerEvents.gripPressed && rightControllerEvents.gripPressed)
        {
            lightningScript.Trigger();
        }
    }

    void InstantiateLightning()
    {
        lightningScript = Instantiate(lightningPrefab).GetComponent<LightningBoltScript>();
        lightningScript.ManualMode = true;
        lightningScript.StartObject = leftController;
        lightningScript.EndObject = rightController;
    }
}
