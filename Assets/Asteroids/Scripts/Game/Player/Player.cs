using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 100f;
        public float rotationSpeed = 360f;
        private Rigidbody2D rigid;

        public GameObject projectilePrefab;

        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Control();
        }

        void Control()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                rigid.AddForce(transform.up * movementSpeed * Time.deltaTime);
            }
        }

        void Shoot()
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            Projectile bullet = projectile.GetComponent<Projectile>();
            bullet.Fire(transform.up);
        }
    }
}

