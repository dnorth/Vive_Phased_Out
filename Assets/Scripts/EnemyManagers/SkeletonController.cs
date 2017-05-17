﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using System.Linq;

public class SkeletonController : IEnemyController {
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        if(target == null)
            target = VRTK_DeviceFinder.HeadsetCamera();

    }

    // Update is called once per frame
    void Update () {
        TurnTowards(target);

        if (IsGrounded())
            return;

        if (!IsInAttackingDistance())
        {
            WalkTowards(target);
        }
        else
        {
            Debug.Log("First time attack...");
            Attack(target);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided!");
    }

    protected override void WalkTowards(Transform target)
    {
        animator.SetBool("isWalking", true);
        MoveTowards(target, walkingSpeed);
    }

    protected override void RunTowards(Transform target)
    {
        animator.SetBool("isRunning", true);
        MoveTowards(target, runningSpeed);
    }

    private void MoveTowards(Transform target, float speed)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GetNonVerticalTargetPos(target), step);
    }

    protected override void Attack(Transform target)
    {
        StartCoroutine(AttackCoroutine(target));
    }

    private IEnumerator AttackCoroutine(Transform target)
    {
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(GetClipLength("Attack"));
        animator.SetBool("isAttacking", false);
    }

    private float GetClipLength(string name)
    {
        return animator.runtimeAnimatorController.animationClips.First(x => x.name == name).length;
    }

    private bool IsGrounded()
    {
        return animator.GetBool("isAttacking") || animator.GetBool("isHit");
    }

    public override void OnHit(GameObject particle)
    {
        StartCoroutine(OnHitCoroutine());
    }

    private IEnumerator OnHitCoroutine()
    {
        animator.SetBool("isHit", true);
        yield return new WaitForSeconds(GetClipLength("Damage"));
        animator.SetBool("isHit", false);
    }
}
