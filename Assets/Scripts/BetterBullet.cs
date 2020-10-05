using System.Collections;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(menuName = "Create BetterBullet", fileName = "BetterBullet", order = 0)]
public class BetterBullet : WeaponsScript
{
    public GameObject[] Bullets;
    public float[] Delays;
    public float[] Angles;
    
    private void SpawnBullet(GameObject gameObject, Transform transform, float angle)
    {
        var clone = Instantiate(gameObject);
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;
        clone.transform.Rotate(Vector3.forward, angle);
        clone.GetComponent<SimpleBullet>().Player = Player;
    }

    private IEnumerator Shoot(Transform transform)
    {

        for (int i = 0; i < Delays.Length; i++)
        {
            var delay = Delays[i];
            var angle = Angles[i % Angles.Length];
            var bullet = Bullets[i % Bullets.Length];
            SpawnBullet(bullet, transform, angle);
            yield return new WaitForSeconds(delay);
        }
    }
    
    public override IEnumerator Activate(Transform transform, float nextTime)
    {
        while (Time.time < nextTime)
        {
            yield return Shoot(transform);
        }
    }
}