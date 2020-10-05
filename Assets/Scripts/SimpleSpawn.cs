using UnityEngine;

[CreateAssetMenu(menuName = "Create SimpleSpawn", fileName = "SimpleSpawn", order = 0)]
public class SimpleSpawn : SpawnSystem
{
    public float width = 10f;
    public float spawnProb = 0.5f;
    
    public GameObject[] enemies;
    public int[] SpawnProb;


    public int Tracks = 8;
    
    
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
        var pos = GetSpawnPos(position, width);
        var obj = Instantiate(enemy.gameObject);
        obj.transform.position = pos;
    }
    
    private Vector3 GetSpawnPos(Vector3 pos, float width)
    {
        var trackOffset = width / Tracks;
        var half = Tracks / 2;
        var r = Random.Range(-half, half);
        var x = r*trackOffset + trackOffset/2;
        return new Vector3(pos.x + x, pos.y, pos.z);
    }


    public override void DrawGizmos(Vector3 position)
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(position, new Vector3(width, 1, 1));
        
        var trackOffset = width / Tracks;
        var half = Tracks / 2;
        for (int i = -half; i <= half; i++)
        {
            var x = i*trackOffset;
            var pos = new Vector3(position.x + x, position.y, position.z);
            Gizmos.DrawRay(pos, Vector3.down);
        }
        
    }
}