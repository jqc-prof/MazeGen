using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JiaVincent.Lab3;
using UnityEngine.InputSystem;
using System;

namespace JiaVincent.Lab3
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private float rotationSpeed = 20f;
        [SerializeField] private float rotationSpeedY = 20f;
        [SerializeField] private float maxVerticalAngle = 80f; // Maximum vertical angle in degrees
        [SerializeField] private float minVerticalAngle = -80f; // Minimum vertical angle in degrees

        private InputAction rotater;
        private float currentXRotation = 0f;

        public void Initialize(InputAction action)
        {
            rotater = action;
            rotater.performed += OnRotate;
        }

        private void OnEnable()
        {
            rotater.Enable();
        }

        private void OnDisable()
        {
            rotater.Disable();
        }

        private void OnRotate(InputAction.CallbackContext context)
        {
            Vector2 rotation = context.ReadValue<Vector2>();
            float mouseX = rotation.x;
            float mouseY = rotation.y;

            // Rotate horizontally based on mouse X movement
            transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);

            // Calculate the new vertical rotation based on mouse Y movement
            currentXRotation -= mouseY * rotationSpeedY;
            currentXRotation = Mathf.Clamp(currentXRotation, minVerticalAngle, maxVerticalAngle);

            // Create the target rotation based on the new vertical rotation
            Quaternion targetRotation = Quaternion.Euler(currentXRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            // Smoothly rotate the camera towards the target rotation
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);

        }

        public void Update()
        {
            Vector3 newPosition = new Vector3(transform.position.x, 6f, transform.position.z);
            transform.position = newPosition;
        }
    }
}