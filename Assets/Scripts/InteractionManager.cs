using DigitalRuby.LightningBolt;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractionManager : MonoBehaviour {

    public ParticleSystem tornadoParticles;
    public Transform body;

    private ParticleSystem tornado;

    private GameObject leftController;
    private GameObject rightController;

    private VRTK_ControllerEvents leftControllerEvents;
    private VRTK_ControllerEvents rightControllerEvents;

    void Awake()
    {
        InitializeControllers();

        tornado = Instantiate(tornadoParticles, body);
    }

    void Update()
    {
        bool gripsHeld = leftControllerEvents.gripPressed && rightControllerEvents.gripPressed;

        if (gripsHeld && !tornado.isPlaying)
        {
            tornado.Play();
        }
        else if (!gripsHeld && tornado.isPlaying )
        {
            tornado.Stop();
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
