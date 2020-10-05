using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public partial class PlayerController : MonoBehaviour
{
    public float Health = 3;
    public int MaxHealth = 5;
    public float HealthPercent { get => Health/MaxHealth; }

    public float Speed = 1f;
    
    public Rect BoundinBox;
    
    private Rigidbody2D _rigidBody;
    
    void Awake() {
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
        var direction = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
        
        var movement = direction * Speed * Time.fixedDeltaTime;
        var clamped = MovementClamp(transform.position + movement, BoundinBox);
        _rigidBody.MovePosition(clamped);
        
    }




    private Vector3 MovementClamp(Vector2 pos, Rect box)
    {
        var x = Mathf.Clamp(pos.x, box.xMin, box.xMax);
        var y = Mathf.Clamp(pos.y, box.yMin, box.yMax);
        return new Vector3(x, y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out EnemyController enemy))
        {
            TakeDamage(enemy.ImpactDamage);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out SimpleBullet simpleBullet))
        {
            if (!simpleBullet.Player)
            {
                TakeDamage(simpleBullet.Dammage);
                Destroy(other.gameObject);
            }
            
        }
    }

    private void TakeDamage(float damage)
    {
        Health = Mathf.Clamp(Health - damage, 0, MaxHealth);
        if (Health <= 0)
        {
            Debug.Log("The player has died.");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(BoundinBox.center, BoundinBox.size);
    }
}
