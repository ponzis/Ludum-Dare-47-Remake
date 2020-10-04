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
        _rigidBody.MovePosition(transform.position + movement);
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
}
