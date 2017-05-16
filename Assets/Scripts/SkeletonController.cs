using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SkeletonController : MonoBehaviour {

    [Tooltip("The target being attacked. If not set, defaults to the HMD.")]
    public Transform target;

    public float walkingSpeed = 0.5f;
    public float runningSpeed = 2f;
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

        if(!IsAttacking() && !IsInAttackingDistance())
        {
            WalkTowards(target);
        }
        else if(!IsAttacking() && IsInAttackingDistance())
        {
            StartCoroutine(Attack(target));
        }
    }

    private void WalkTowards(Transform target)
    {
        animator.SetBool("isWalking", true);
        MoveTowards(target, walkingSpeed);
    }

    private void RunTowards(Transform target)
    {
        animator.SetBool("isRunning", true);
        MoveTowards(target, runningSpeed);
    }

    private void MoveTowards(Transform target, float speed)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GetNonVerticalTargetPos(target), step);
    }

    private void TurnTowards(Transform target)
    {
        transform.LookAt(GetNonVerticalTargetPos(target));
    }

    private IEnumerator Attack(Transform target)
    {
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(2.767f);
        if (IsInAttackingDistance())
        {
            StartCoroutine(Attack(target));
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttacking()
    {
        return animator.GetBool("isAttacking");
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
