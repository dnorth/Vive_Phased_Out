using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class IProjectile : MonoBehaviour {

    public Color Color = Color.HSVToRGB(269, 233, 193);
    protected float Cooldown = 0.5f;
    public float NextFire { get; private set; }

    abstract public void Cast();

    public void UpdateNextFire()
    {
        NextFire = Time.time + Cooldown;
    }
}
