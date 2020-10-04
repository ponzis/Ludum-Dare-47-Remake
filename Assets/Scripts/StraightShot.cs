using UnityEngine;
using UnityEngine.Serialization;

public class StraightShot : WeaponsController
{
    public float speed = 25;

    public float lifeTime = 5f;

    private float _nextTime;
    
    public override bool Activate()
    {

        if (Time.time > _nextTime)
        {
            var clone = Instantiate(bullet, transform.position, transform.rotation);
            Destroy(clone, lifeTime);
            Debug.Log($"Creating {lifeTime}");
            clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed);
            _nextTime = Time.time + spawnDelay;
            _audioSource.Play();
            return true;
        }

        return false;
    }
}