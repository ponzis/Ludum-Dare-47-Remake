using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    private void SetHealth(int value)
    {
        _health = value;
       
        _healthIndicator.Health = HealthPercent;
    }
    
    
    [SerializeField]
    private int _health = 3;
    
    public int Health
    {
        set => SetHealth(value);
        get => _health;
    }
    
    public int MaxHealth = 5;
    
    public float HealthPercent { get => (float) Health/MaxHealth; }

    public float Speed = 1f;
    
    public Rect BoundinBox;
    
    private Vector3 _direction  = Vector3.zero;
    
    public  HealthIndicator _healthIndicator;
    public WeaponsController _weapons;
    
    private Rigidbody2D _rigidBody;
    
    void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
        //TODO remove
        Health = _health;
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
        Debug.Log("Hit");
        foreach (var contact in other.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        
        var enemy = other.collider.GetComponent<EnemyController>();
        if(enemy)
        {
            SetHealth(0);
            Destroy(other.gameObject);
        }
    }
    
    
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(BoundinBox.center, BoundinBox.size);
    }
}
