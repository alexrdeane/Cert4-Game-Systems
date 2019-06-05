using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MadFlex
{
    public class LookAtEnemy : MonoBehaviour
    {
        private Renderer rend;
        private Collider collide;

        void Start()
        {
            collide = this.GetComponent<BoxCollider>();
            rend = this.GetComponent<MeshRenderer>();
            rend.enabled = true;
        }

        // Toggle the Object's visibility each second.
        void Update()
        {
            if (collide.gameObject.tag == "Player")
            {
                bool oddeven = false;

                // Enable renderer accordingly
                rend.enabled = oddeven;
            }

        }
    }
}
