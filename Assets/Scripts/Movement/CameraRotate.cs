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
        private InputAction rotater;

        [SerializeField] private float rotationSpeed = 1.5f;

        [SerializeField] private float maxVerticalAngle = 80f; // Maximum vertical angle in degrees
        [SerializeField] private float minVerticalAngle = -80f; // Minimum vertical angle in degrees

        private float currentXRotation = 0f;

        public void Initialize(InputAction action)
        {
            rotater = action;
            rotater.Enable();
            rotater.performed += OnRotate;
        }

        private void OnRotate(InputAction.CallbackContext context)
        {
            Vector2 rotation = context.ReadValue<Vector2>();
            float mouseX = rotation.x;
            float mouseY = rotation.y;

            // Rotate horizontally based on mouse X movement
            transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);

            // Calculate the new vertical rotation based on mouse Y movement
            currentXRotation -= mouseY * rotationSpeed;
            currentXRotation = Mathf.Clamp(currentXRotation, minVerticalAngle, maxVerticalAngle);

            // Create the target rotation based on the new vertical rotation
            Quaternion targetRotation = Quaternion.Euler(currentXRotation, 0f, 0f);

            // Rotate the camera towards the target rotation using Quaternion.RotateTowards
            cam.transform.localRotation = Quaternion.Euler(targetRotation.eulerAngles.x, cam.transform.localRotation.eulerAngles.y, cam.transform.localRotation.eulerAngles.z);

            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        public void Update()
        {
            Vector3 newPosition = new Vector3(transform.position.x, 6f, transform.position.z);
            transform.position = newPosition;
        }
    }
}