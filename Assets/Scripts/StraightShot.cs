using UnityEngine;
using UnityEngine.Serialization;

public class StraightShot : WeaponsController
{
    [FormerlySerializedAs("Speed")] public float speed = 25;

    [FormerlySerializedAs("LifeTime")] public float lifeTime = 5f;

    [FormerlySerializedAs("SpawnDelay")] public float spawnDelay = 2f;

    private float _nextTime;
    
    public override void Activate()
    {

        if (Time.time > _nextTime)
        {
            var clone = Instantiate(bullet, transform.position, transform.rotation);
            Destroy(clone, lifeTime);
            Debug.Log($"Creating {lifeTime}");
            clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed);
            _nextTime = Time.time + spawnDelay;
        }

    }
}