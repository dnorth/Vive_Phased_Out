using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class IEnemyController : MonoBehaviour
{
    [Tooltip("The target to attack. If not set, defaults to the HMD.")]
    public Transform target;

    public float walkingSpeed = 0.5f;
    public float runningSpeed = 2f;
    public float turningSpeed = 100f;
    public float attackingDistance = 1f;

    abstract protected void Attack(Transform target);
    abstract protected void WalkTowards(Transform target);
    abstract protected void RunTowards(Transform target);
    abstract public void OnHit(GameObject particle);


    protected bool IsInAttackingDistance()
    {
        return Vector3.Distance(transform.position, GetNonVerticalTargetPos(target)) <= attackingDistance;
    }

    protected Vector3 GetNonVerticalTargetPos(Transform target)
    {
        return new Vector3(target.position.x, transform.position.y, target.position.z);
    }

    protected void TurnTowards(Transform target)
    {
        transform.LookAt(GetNonVerticalTargetPos(target));
    }
}
