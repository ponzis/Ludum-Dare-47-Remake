using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;




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
    public float delay = 0.2f;
    
    private void SpawnBullet(GameObject gameObject, Transform transform)
    {
        var clone = Instantiate(gameObject);
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;
        clone.GetComponent<SimpleBullet>().Player = Player;
    }

    public override IEnumerator Activate(Transform transform, float nextTime)
    {
        while (Time.time < nextTime)
        {
            SpawnBullet(bullet, transform);
            yield return new WaitForSeconds(delay);
            SpawnBullet(bullet, transform);
            yield return new WaitForSeconds(delay * 2);
            SpawnBullet(largeBullet, transform);
            yield return new WaitForSeconds(delay);
        }
    }
}