using UnityEngine;

[CreateAssetMenu(menuName = "Create SimpleSpawn", fileName = "SimpleSpawn", order = 0)]
public class SimpleSpawn : SpawnSystem
{
    public float offset = 1f;
    public float spawnProb = 0.5f;
    
    public GameObject[] enemies;
    public int[] SpawnProb;
    
    
    private int GetProbSum()
    {
        var sum = 0;
        foreach (var prob in SpawnProb)
        {
            sum += prob;
        }
        return sum;
    }

    
    public override void Spawn(Vector3 position)
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
                    SpawnEnemy(enemy, position);
                }
            }
        }
    }
    
    private void SpawnEnemy(GameObject enemy, Vector3 position)
    {
        Debug.Log($"Spawning {enemy.name}");
        var pos = GetSpawnPos(position, offset);
        var obj = Instantiate(enemy.gameObject);
        obj.transform.position = pos;
    }
    
    private Vector3 GetSpawnPos(Vector3 pos, float offset)
    {
        
        var x = Random.Range(-offset, offset);
        //Fix onto 8 bands
        return new Vector3(pos.x + x, pos.y, pos.z);
    }


    public override void DrawGizmos(Vector3 position)
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(position, new Vector3(offset*2, 1, 1));
    }
}