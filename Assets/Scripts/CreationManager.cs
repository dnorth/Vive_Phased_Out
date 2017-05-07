using DigitalRuby.LightningBolt;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using Assets.Scripts.Extensions;

public class CreationManager : MonoBehaviour {

    public GameObject lightningPrefab;

    private VRTK_ControllerEvents controllerEvents;
    private GameObject lightning;

    void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();

        controllerEvents.GripPressed += OnGripPressed;
        controllerEvents.GripReleased += OnGripReleased;
    }

    private void OnGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        Destroy(lightning);
    }

    public void OnGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        lightning = Instantiate(lightningPrefab);
        var lightningScript = lightning.GetComponent<LightningBoltScript>();
        lightningScript.StartObject = gameObject.FindInChildren("StartLightning");
        lightningScript.EndObject = gameObject.FindInChildren("EndLightning");
    }
}
