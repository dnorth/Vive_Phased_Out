using Assets.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RadialMenuManager : MonoBehaviour {

    private VRTK_ControllerEvents controllerEvents;
    private RadialMenu radialMenu;
	// Use this for initialization
	void Start () {
        controllerEvents = GetComponentInParent<VRTK_ControllerEvents>();
        radialMenu = gameObject.FindInChildren<RadialMenu>();
    }

    // Update is called once per frame
    void Update () {
        if(controllerEvents.touchpadPressed)
        {
            radialMenu.ShowMenu();
        }
        else
        {
            radialMenu.HideMenu(true);
        }
	}
}
