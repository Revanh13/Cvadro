using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drone
{
    [RequireComponent(typeof(PlayerInput))]
    public class DroneInputs : MonoBehaviour
    {
        public float vertical;
        public float horizontal;
        public float pedals;
        public float throttle;

        public float Vertical { get => vertical; }
        public float Horizontal { get => horizontal; }
        public float Pedals { get => pedals; }
        public float Throttle { get => throttle; }

        void Update()
        {

        }

        private void OnVertical(InputValue value)
        {
            vertical = value.Get<float>();
        }

        private void OnHorizontal(InputValue value)
        {
            horizontal = value.Get<float>();
        }

        private void OnPedals(InputValue value)
        {
            pedals = value.Get<float>();
        }

        private void OnThrottle(InputValue value)
        {
            throttle = value.Get<float>();
        }
    }

}
