using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SkeletonController : MonoBehaviour {

    public float speed = 3f;

    private Transform headset;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        headset = VRTK_DeviceFinder.HeadsetCamera();

        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update () {
        float step = speed * Time.deltaTime;
        var headsetPosNoVertical = new Vector3(headset.position.x, transform.position.y, headset.position.z);
        transform.position = Vector3.MoveTowards(transform.position, headsetPosNoVertical, step);
    }
}
