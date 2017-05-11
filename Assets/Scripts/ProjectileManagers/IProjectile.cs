using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class IProjectile : MonoBehaviour {
    protected float Cooldown = 1f;
    public float NextFire { get; private set; }

    abstract public void Cast();

    public void UpdateNextFire()
    {
        NextFire = Time.time + Cooldown;
    }
}
