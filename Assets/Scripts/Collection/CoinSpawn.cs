using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JiaVincent.Lab3
{
    public class CoinSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject coinToSpawn;
        private string partialName = "TrueCell";
        private string partialName2 = "FalseCell";

        void Start()
        {
            int childCount = transform.childCount;

            for (int childIndex = 2; childIndex < childCount; childIndex++)
            {
                Transform previousChild = transform.GetChild(childIndex - 2);
                Transform currentChild = transform.GetChild(childIndex - 1);
                Transform nextChild = transform.GetChild(childIndex);

                // Check if current or previous child's name contains the partial match
                bool currentChildMatch = currentChild.name.Contains(partialName);
                bool nextChildMatch = nextChild.name.Contains(partialName2);
                bool previousChildMatch = previousChild.name.Contains(partialName2);

                if (currentChildMatch && (nextChildMatch || previousChildMatch))
                {
                    GameObject.Instantiate<GameObject>(coinToSpawn, currentChild.position + new Vector3(0f, 5.5f, 0f), Quaternion.identity);
                }

                previousChild = currentChild;
            }
        }
    }
}