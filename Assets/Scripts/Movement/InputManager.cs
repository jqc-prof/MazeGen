using JiaVincent.Lab3;
using UnityEngine;

namespace JiaVincent.Lab3
{
    public class InputManager : MonoBehaviour
    {
        //Intialize movement handler script
        [SerializeField] private CameraMove cameraMover;
        [SerializeField] private CameraRotate cameraRotater;
        //Intialize the Player Inputs asset in inputs folder
        private Movement inputScheme;
        private void Awake()
        {
            inputScheme = new Movement();
            cameraMover.Initialize(inputScheme.Move.Movement);
            cameraRotater.Initialize(inputScheme.Move.CameraRotate);
        }

    }
}