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
    private ProjectileMeteorManager meteorManager;

    private IProjectile currentProjectile;

    void Awake()
    {

        controllerEvents = GetComponent<VRTK_ControllerEvents>();

        controllerEvents.GripPressed += OnGripPressed;
        controllerEvents.TouchpadAxisChanged += OnTouchpadAxisChanged;

        basicProjectileManager = GetComponent<ProjectileBasicManager>();
        blackholeManager = GetComponent<ProjectileBlackholeManager>();
        meteorManager = GetComponent<ProjectileMeteorManager>();

        currentProjectile = basicProjectileManager;
    }

    /*
                      0
                    *  *      
                 *        *     
           270  *          *  90    
                *          *    
                 *        *     
                    *  *
                    180       
    */
    private void OnTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
        if(controllerEvents.touchpadPressed)
        {
            if(e.touchpadAngle > 240)
            {
                currentProjectile = basicProjectileManager;
            }
            else if (e.touchpadAngle > 120)
            {
                currentProjectile = blackholeManager;
            }
            else
            {
                currentProjectile = meteorManager;
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

