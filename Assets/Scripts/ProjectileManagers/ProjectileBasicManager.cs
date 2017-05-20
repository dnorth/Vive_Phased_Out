using Assets.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBasicManager : IProjectile {

    public GameObject basicHandPrefab;
    public GameObject basicPrefab;

    public void Awake()
    {
        basicPrefab.GetOrAddComponent<RFX4_EffectSettingColor>().Color = Color;
        basicHandPrefab.GetOrAddComponent<RFX4_EffectSettingColor>().Color = Color;
    }

    public override void Cast() {
        UpdateNextFire();
        var boltHand = Instantiate(basicHandPrefab, transform, false);
        Destroy(boltHand, 2.5f);
        var bolt = Instantiate(basicPrefab, transform.position, transform.rotation);
        Destroy(bolt, 2.5f);
    }
}
