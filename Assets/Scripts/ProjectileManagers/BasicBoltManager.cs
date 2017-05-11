using Assets.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoltManager : IProjectile {

    public GameObject boltHandPrefab;
    public GameObject boltPrefab;

    public Color Color = Color.green;

    public void Awake()
    {
        boltPrefab.GetOrAddComponent<RFX4_EffectSettingColor>().Color = Color;
        boltHandPrefab.GetOrAddComponent<RFX4_EffectSettingColor>().Color = Color;

        Cooldown = 0.5f;
    }

    public override void Cast() {
        UpdateNextFire();
        var boltHand = Instantiate(boltHandPrefab, transform.position, transform.rotation);
        Destroy(boltHand, 2.5f);
        var bolt = Instantiate(boltPrefab, transform.position, transform.rotation);
        Destroy(bolt, 2.5f);
    }
}
