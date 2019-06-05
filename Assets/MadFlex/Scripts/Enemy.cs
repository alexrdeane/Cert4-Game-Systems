using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MadFlex
{
    public class Enemy : MonoBehaviour
    {

        public Renderer rend;
        #region Variables
        [Header("Variables:")]
        //enemy's rigidbody
        public Rigidbody rigid;

        private Transform target;
        #endregion Variables

        #region Start
        void Start()
        {
            rend = GetComponent<Renderer>();
            rend.enabled = false;

        }
        #endregion

        #region Update
        void Update()
        {

        }
        #endregion

        #region TriggerEnter
        private void OnTriggerEnter(Collider other)
        {
            //if other gameobject is player
            if (other.gameObject.CompareTag("Player"))
            {
                //set target to the thing in zone
                target = other.transform;
                //switch state to seek
                rend.enabled = true;
            }

        }
        #endregion

        #region TriggerExit
        private void OnTriggerExit(Collider other)
        {
            //if other gameobject is player
            if (other.gameObject.CompareTag("Player"))
            {
                rend.enabled = false;
            }
        }
        #endregion
    }
}

