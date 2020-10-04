using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{

    public float Speed = 1f;
    public int Health = 5;
    
    
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void FixedUpdate()
    {
        var movement = Vector3.down * Speed * Time.fixedDeltaTime;
        _rigidBody.MovePosition(transform.position + movement);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Hit enemy. {other.name}");
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
