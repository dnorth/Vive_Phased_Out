using Assets.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBlackholeManager : IProjectile {
    public GameObject blackholePrefab;

    public void Awake()
    {
        blackholePrefab.GetOrAddComponent<RFX4_EffectSettingColor>().Color = Color;
    }

    public override void Cast()
    {
        UpdateNextFire();
        var voidProjectile = Instantiate(blackholePrefab, transform.position, transform.rotation);
        Destroy(voidProjectile, 2.5f);
    }
}
