using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JiaVincent.Lab3;

namespace JiaVincent.Lab3
{
    public class ExitTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collide)
        {
            EventManager eventManager = FindObjectOfType<EventManager>();
            if (collide.CompareTag("Player"))
            {
                eventManager.GameOver();
            }
        }
    }
}
