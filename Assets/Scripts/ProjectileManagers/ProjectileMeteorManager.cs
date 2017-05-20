using Assets.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMeteorManager : IProjectile {

    public GameObject meteorHandPrefab;
    public GameObject meteorPrefab;

    public void Awake()
    {
        meteorPrefab.GetOrAddComponent<RFX4_EffectSettingColor>().Color = Color;
        meteorHandPrefab.GetOrAddComponent<RFX4_EffectSettingColor>().Color = Color;
    }

    public override void Cast()
    {
        UpdateNextFire();
        var meteorHand = Instantiate(meteorHandPrefab, transform, false);
        Destroy(meteorHand, 3f);
        //var meteor = Instantiate(meteorPrefab, transform.position + Vector3.forward * 2f, transform.rotation);
        //Destroy(meteor, 2.5f);
    }
}
