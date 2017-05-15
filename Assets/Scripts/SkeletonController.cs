using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SkeletonController : MonoBehaviour {

    [Tooltip("The target being attacked. If not set, defaults to the HMD.")]
    public Transform target;

    public float walkingSpeed = 3f;
    public float turningSpeed = 100f;
    public float attackingDistance = 1f;

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

        Debug.Log("Is move allowed: " + IsMoveAllowed());
        if(IsMoveAllowed() && !IsInAttackingDistance())
        {
            WalkTowards(target);
        }
        else
        {
            Attack(target);
        }
    }

    private void WalkTowards(Transform target)
    {
        animator.SetBool("isWalking", true);
        float walkingStep = walkingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GetNonVerticalTargetPos(target), walkingStep);
    }

    private void TurnTowards(Transform target)
    {
        transform.LookAt(GetNonVerticalTargetPos(target));
    }

    private void Attack(Transform target)
    {
        animator.SetTrigger("attack");
    }

    private bool IsMoveAllowed()
    {
        return !animator.GetBool("attack");
    }

    private bool IsInAttackingDistance()
    {
        return Vector3.Distance(transform.position, GetNonVerticalTargetPos(target)) <= attackingDistance;
    }

    private Vector3 GetNonVerticalTargetPos(Transform target)
    {
        return new Vector3(target.position.x, transform.position.y, target.position.z);
    }
}
