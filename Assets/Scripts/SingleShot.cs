using System.Collections;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(menuName = "Create SingleShot", fileName = "SingleShot", order = 0)]
public class SingleShot : WeaponsScript
{
    public GameObject bullet;
    private void SpawnBullet(GameObject gameObject, Transform transform)
    {
        var clone = Instantiate(gameObject);
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;
        clone.GetComponent<SimpleBullet>().Player = Player;
    }
    
    public override IEnumerator Activate(Transform transform, float nextTime)
    {
        SpawnBullet(bullet, transform);
        yield return null;
    }
}