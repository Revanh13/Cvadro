﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drone
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaseRigidbody : MonoBehaviour
    {
        [Header("Rigidbody Properties")]
        [SerializeField] private float weightInKg = 1f;

        protected Rigidbody rb;
        protected float startDrag;
        protected float startAngularDrag;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.mass = weightInKg;
                startDrag = rb.drag;
                startAngularDrag = rb.angularDrag;
            }
        }

        void FixedUpdate()
        {
            if (!rb)
            {
                return;
            }

            HandlePhysics();
        }

        protected virtual void HandlePhysics() { }
    }
}

