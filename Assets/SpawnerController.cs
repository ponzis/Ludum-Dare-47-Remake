using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public float offset = 1f;

    public float spawnCooldown = 1f;
    
    public GameObject[] enemies;
    public int[] SpawnProb;
    
    
    public float spawnProb = 0.5f;


    private float _nextSpawn;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextSpawn)
        {
            AttemptSpawn();
            
            _nextSpawn = Time.time + spawnCooldown;
        }
    }

    private void AttemptSpawn()
    {
        if (Random.Range(0, 1) < spawnProb)
        {
            var score = Random.Range(0, GetProbSum());
            var sum = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                var enemy = enemies[i];
                sum += SpawnProb[i];
                if (sum > score)
                {
                    SpawnEnemy(enemy);
                }
            }
            
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Debug.Log($"Spawning {enemy.name}");
        var pos = GetSpawnPos(transform.position, offset);
        var obj = Instantiate(enemy.gameObject);
        obj.transform.position = pos;
    }

    private int GetProbSum()
    {
        var sum = 0;
        foreach (var prob in SpawnProb)
        {
            sum += prob;
        }
        return sum;
    }

    private Vector3 GetSpawnPos(Vector3 pos, float offset)
    {
        
        var x = Random.Range(-offset, offset);
        //Fix onto 8 bands
        return new Vector3(pos.x + x, pos.y, pos.z);
    }
    
    
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(offset*2, 1, 1));
    }
}
