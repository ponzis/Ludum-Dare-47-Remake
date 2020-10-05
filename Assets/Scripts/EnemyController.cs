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
    public float Health = 5;


    public WeaponsScript weapon;
    private Rigidbody2D _rigidBody;
    
    public Transform FacingTransform;
    public float delay = 4f;
    private float _next;
    public float ImpactDamage = 10;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Time.time > _next)
        {
            Debug.Log($"Transform {transform}");
            StartCoroutine(weapon.Activate(FacingTransform, Time.time + weapon.spawnDelay));
            _next = Time.time + delay;
        }
        
        
        
    }
    
    private void FixedUpdate()
    {
        var movement = FacingTransform.right * (Speed * Time.fixedDeltaTime);
        _rigidBody.MovePosition(transform.position + movement);
    }

    private void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Hit enemy. {other.name}");
        if (other.TryGetComponent(out SimpleBullet simpleBullet))
        {
            if (simpleBullet.Player)
            {
                TakeDamage(simpleBullet.Dammage);
                Destroy(other.gameObject);
            }
        }
        
    }
}
