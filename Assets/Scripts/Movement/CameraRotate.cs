using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JiaLab3;
using UnityEngine.InputSystem;
using System;

namespace JiaLab3
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private float speed;
        private InputAction rotater;
        private Vector2 contextValue;
        // Start is called before the first frame update
        public void Initialize(InputAction action)
        {
            this.rotater = action;
            rotater.Enable();
            rotater.performed += OnCameraRotate;
        }

        void FixedUpdate()
        {
                Quaternion deltaRotation = Quaternion.Euler(contextValue.y, contextValue.x, 0f);
                Quaternion targetRotation = cam.transform.rotation * deltaRotation;
                cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, targetRotation, speed * Time.deltaTime);
                contextValue = Vector2.zero;
        }

        private void OnCameraRotate(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            contextValue = input;
        }


    }
}