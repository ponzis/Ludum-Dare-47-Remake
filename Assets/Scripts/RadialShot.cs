using System.Collections;
using DefaultNamespace;
using UnityEngine;


[CreateAssetMenu(menuName = "Create RadialShot", fileName = "RadialShot", order = 0)]
public class RadialShot : WeaponsScript
{
    public GameObject bullet;
    public float delay = 0.2f;
    public int pedals = 5;
    public float angle = 180f;


    private void SpawnBullet(GameObject gameObject, Transform transform)
    {
        var dev = angle / pedals;
        for (float i = -(angle / 2); i <= (angle / 2); i+=dev)
        {
            var rot = transform.rotation.eulerAngles;
            rot.z += i;
            var clone = MakeBullet(gameObject, transform.position, rot);
        }
    }

    private GameObject MakeBullet(GameObject gameObject, Vector3 pos, Vector3 rot)
    {
        var clone = Instantiate(gameObject);
        clone.transform.position = pos;
        clone.transform.rotation = Quaternion.Euler(rot);
        clone.GetComponent<SimpleBullet>().Player = Player;
        return clone;
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
            }
            locked = false;
        }
    }
    
}