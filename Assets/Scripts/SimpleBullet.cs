using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SimpleBullet : MonoBehaviour
    {
        public bool Player;
        public float Speed;
        public float LifeTime;
        public float Dammage;
        
        

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Destroy(gameObject, LifeTime);
        }

        private void FixedUpdate()
        {
            var movement = transform.right * (Speed * Time.fixedDeltaTime);
            _rigidbody2D.MovePosition(transform.position + movement);
        }
    }
}