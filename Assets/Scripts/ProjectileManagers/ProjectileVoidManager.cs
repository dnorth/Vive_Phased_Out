using Assets.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVoidManager : IProjectile {
    public GameObject voidHandPrefab;
    public GameObject voidPrefab;

    public void Awake()
    {
        Cooldown = 2.0f;
    }

    public override void Cast()
    {
        UpdateNextFire();
        var voidHand = Instantiate(voidHandPrefab, transform.position, transform.rotation);
        Destroy(voidHand, 2.5f);
        var voidProjectile = Instantiate(voidPrefab, transform.position, transform.rotation);
        Destroy(voidProjectile, 2.5f);
    }
}
