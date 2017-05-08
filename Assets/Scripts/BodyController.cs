using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BodyController : MonoBehaviour {

    private Transform headTransform;

	// Use this for initialization
	void Start () {
        headTransform = VRTK_DeviceFinder.HeadsetTransform();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(headTransform.position.x, transform.position.y, headTransform.position.z);
    }
}
