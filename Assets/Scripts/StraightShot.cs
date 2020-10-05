using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(menuName = "Create StraightShot", fileName = "StraightShot", order = 0)]
public class StraightShot : WeaponsScript
{
    public GameObject bullet;
    public GameObject largeBullet;
    public float speed = 25;

    public float lifeTime = 5f;
    public float delay = 0.2f;
    
    private void SpawnBullet(GameObject gameObject, Transform transform)
    {
        var clone = Instantiate(gameObject, transform);
        Destroy(clone, lifeTime);
        clone.GetComponent<SimpleBullet>().Player = Player;
        clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed);
    }

    public override IEnumerator Activate(Transform transform, float nextTime)
    {

        if (!locked)
        {
            locked = true;
            while (Time.time < nextTime)
            {
                SpawnBullet(bullet, transform);
                yield return new WaitForSeconds(delay);
                SpawnBullet(bullet, transform);
                yield return new WaitForSeconds(delay * 2);
                SpawnBullet(largeBullet, transform);
                yield return new WaitForSeconds(delay);
            }
            locked = false;
        }
    }
}


