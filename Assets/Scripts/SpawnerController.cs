using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public float spawnCooldown = 1f;

    public SpawnSystem spawner;

    private float _nextSpawn;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextSpawn)
        {
            spawner.Spawn(transform.position);
            _nextSpawn = Time.time + spawnCooldown;
        }
    }
    
    void OnDrawGizmosSelected()
    {
        spawner.DrawGizmos(transform.position);
    }
}