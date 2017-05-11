using DigitalRuby.LightningBolt;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using Assets.Scripts.Extensions;

public class ProjectileManager : MonoBehaviour
{
    private VRTK_ControllerEvents controllerEvents;
    private GameObject projectile;

    private BasicBoltManager boltManager;

    void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();

        controllerEvents.GripPressed += OnGripPressed;

        boltManager = GetComponent<BasicBoltManager>();
    }

    public void OnGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        if(Time.time >= boltManager.NextFire)
        {
            boltManager.Cast();
        }
    }
}

