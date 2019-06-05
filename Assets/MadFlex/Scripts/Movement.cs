using UnityEngine;
using System.Collections;

namespace MadFlex
{
    public class Movement : MonoBehaviour
    {
        #region Variables
        [Header("PLAYER MOVEMENT")]
        [Header("______________________________")]
        [Space(5)]
        [Header("Characters MoveDirection")]

        public Vector3 moveDirection;
        private CharacterController _characterController;
        [Header("Character Variables")]

        public float jumpSpeed = 10;
        public float speed = 5;
        public float gravity = 20;
        private float sphereCollide = 5f;
        #endregion
        #region Start
        void Start()
        {
            //charc is on this game object we need to get the character controller that is attached to it
            _characterController = this.GetComponent<CharacterController>();
        }

        #endregion
        #region Update
        void Update()
        {
            if (_characterController.isGrounded)
            {

                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                /*
                if (Input.GetButton("Jump"))
                {
                    //our moveDir.y is equal to our jump speed
                    moveDirection.y = jumpSpeed;
                }
                */

            }

            moveDirection.y -= gravity * Time.deltaTime;

            _characterController.Move(moveDirection * Time.deltaTime);

            #region SelfLearn
            /*
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * speed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;


            */
            #endregion
        }

        #endregion
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, sphereCollide);
        }
    }
}











