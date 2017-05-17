using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTestScript : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I've felt the collision!");
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("I've felt the trigger!");
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("I've felt the particles!!");
    }
}
