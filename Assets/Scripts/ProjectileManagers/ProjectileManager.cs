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

    private ProjectileBasicManager basicProjectileManager;
    private ProjectileBlackholeManager blackholeManager;

    private IProjectile currentProjectile;

    void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();

        controllerEvents.GripPressed += OnGripPressed;
        controllerEvents.TouchpadAxisChanged += OnTouchpadAxisChanged;

        basicProjectileManager = GetComponent<ProjectileBasicManager>();
        blackholeManager = GetComponent<ProjectileBlackholeManager>();

        currentProjectile = basicProjectileManager;
    }

    private void OnTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
        if(controllerEvents.touchpadPressed)
        {
            if(e.touchpadAngle > 180)
            {
                currentProjectile = basicProjectileManager;
            }
            else
            {
                currentProjectile = blackholeManager;
            }
        }
    }

    public void OnGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        if(Time.time >= currentProjectile.NextFire)
        {
            currentProjectile.Cast();
        }
    }
}

