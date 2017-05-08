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

    public ParticleSystem projectilePrefab;

    private VRTK_ControllerEvents controllerEvents;
    private GameObject projectile;

    void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();

        controllerEvents.GripPressed += OnGripPressed;
    }

    public void OnGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Destroy(projectile.gameObject, 2f);
    }
}

