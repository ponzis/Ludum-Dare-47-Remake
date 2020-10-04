using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class StraightShot : WeaponsController
{
    public GameObject bullet;
    public GameObject large_bullet;
    public float speed = 25;

    public float lifeTime = 5f;
    public float delay = 0.2f;
    
    private float _nextTime;
    
    public override bool Activate()
    {

        if (Time.time > _nextTime)
        {
            _audioSource.Play();
            StartCoroutine(BulletTimer());
            _nextTime = Time.time + spawnDelay;
            return true;
        }

        return false;
    }


    private void SpawnBullet(GameObject gameObject)
    {
        var clone = Instantiate(gameObject, transform.position, transform.rotation);
        Destroy(clone, lifeTime);
        clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed);
    }

    IEnumerator BulletTimer()
    {
        while (_audioSource.isPlaying)
        {
            SpawnBullet(bullet);
            yield return new WaitForSeconds(delay);
            SpawnBullet(bullet);
            yield return new WaitForSeconds(delay*2);
            SpawnBullet(large_bullet);
            yield return new WaitForSeconds(delay);
        }
    }
    
}