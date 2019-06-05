using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Movement : MonoBehaviour
    {
        public float speed = 100f;
        public float rotationSpeed = 360f;

        private Rigidbody2D rigid;

        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
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
                rigid.AddForce(transform.up * speed * Time.deltaTime);
            }
        }
    }
}

