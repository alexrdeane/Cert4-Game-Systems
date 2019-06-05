using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace space
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speedZ = 120f;
        public float dodgeSpeed;
        public float boost = 3;
        public float rotationSpeed = 360f;
        public float stoppingSpeed = 0.975f;
        public float brakeSpeed = 0f;
        public float strafeDelay = 0.5f;
        public float gravity = 20f;

        public float dodgeTimer = 0f;
        private Rigidbody rigid;

        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        void Update()
        {
            dodgeTimer += Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
            {
                rigid.AddForce(transform.forward * speedZ * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                rigid.AddForce(transform.forward * speedZ * boost * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rigid.velocity = rigid.velocity * stoppingSpeed;
                rigid.angularVelocity = rigid.angularVelocity * stoppingSpeed;
            }

            if (Input.GetKeyDown(KeyCode.A) && dodgeTimer >= strafeDelay)
            {
                transform.Translate(Vector3.right * -speedZ * Time.deltaTime);
                dodgeTimer = 0f;
            }

            if (Input.GetKeyDown(KeyCode.D) && dodgeTimer >= strafeDelay)
            {
                transform.Translate(Vector3.right * speedZ * Time.deltaTime);
                dodgeTimer = 0f;
            }
        }
    }
}
