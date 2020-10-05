using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public float Speed = 1f;
    public int Health = 5;


    public WeaponsScript weapon;
    private Rigidbody2D _rigidBody;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (!weapon.locked)
        {
            StartCoroutine(weapon.Activate(transform, Time.time + weapon.spawnDelay));
        }
    }
    
    private void FixedUpdate()
    {
        var movement = Vector3.down * Speed * Time.fixedDeltaTime;
        _rigidBody.MovePosition(transform.position + movement);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Hit enemy. {other.name}");
        if (other.GetComponent<SimpleBullet>().Player)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }
}
