using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class EnemySpawnManager : MonoBehaviour {

    [Tooltip("Time you want the first enemy to spawn.")]
    public float startTime = 1f;

    [Tooltip("Time between spawning enemies.")]
    public float frequency = 4f;

    [Tooltip("Max number of enemies you want to spawn. If 0, enemies will spawn infinitely.")]
    public float maxSpawn = 0;

    public GameObject enemy;

    private Transform headset;
    private int enemiesSpawned = 0;
	// Use this for initialization
	void Start () {
        headset = VRTK_DeviceFinder.HeadsetCamera();
        InvokeRepeating("SpawnEnemy", startTime, frequency);
	}
	
    void SpawnEnemy()
    {
        enemiesSpawned++;
        var enemyPos = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y, transform.position.z + Random.Range(-0.5f, 0.5f));
        var relativePos = headset.position - transform.position;
        Instantiate(enemy, enemyPos, Quaternion.LookRotation(relativePos));
    }

    void Update()
    {
        if(maxSpawn != 0 && enemiesSpawned == maxSpawn)
        {
            CancelInvoke();
        }
    }
}
