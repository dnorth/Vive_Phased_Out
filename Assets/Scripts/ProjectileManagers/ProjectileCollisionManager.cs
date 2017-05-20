using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollisionManager : MonoBehaviour {

    void Start()
    {
        var tm = GetComponentInChildren<RFX4_TransformMotion>(true);
        if (tm != null) tm.CollisionEnter += Tm_CollisionEnter;
    }

    private void Tm_CollisionEnter(object sender, RFX4_TransformMotion.RFX4_CollisionInfo e)
    {
        var enemy = e.Hit.transform.gameObject.GetComponentInParent<IEnemyController>();

        if (enemy != null) enemy.OnHit(gameObject);
    }
}
