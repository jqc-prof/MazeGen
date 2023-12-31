using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JiaVincent.Lab3;
using UnityEngine.InputSystem;
using System;

namespace JiaVincent.Lab3
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private float speed;
        private InputAction mover;
        private Vector2 contextValue;
        private Rigidbody camRigidbody;

        void Start()
        {
            camRigidbody = GetComponent<Rigidbody>();
            camRigidbody.freezeRotation = true;
        }

        // Start is called before the first frame update
        public void Initialize(InputAction action)
        {
            this.mover = action;
            mover.Enable();
            mover.performed += OnCameraMovement;
            mover.canceled += OnCameraMovementCancel;
        }

        void FixedUpdate()
        {
            camRigidbody.velocity = Vector3.zero;
            camRigidbody.angularVelocity = Vector3.zero;
            Vector3 localMovement = cam.transform.TransformDirection(new Vector3(contextValue.x, 0f, contextValue.y)) * speed * Time.deltaTime;
            Vector3 newPosition = cam.transform.position + localMovement;
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, newPosition, speed * Time.deltaTime);
        }

        private void OnCameraMovement(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            contextValue = input;
        }

        private void OnCameraMovementCancel(InputAction.CallbackContext context)
        {
            contextValue = Vector2.zero;
        }

    }
}