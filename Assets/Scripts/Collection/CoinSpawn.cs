using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShareefSoftware;

namespace JiaVincent.Lab3
{
    public class CoinSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject coinToSpawn;
        private string partialName = "TrueCell";

        void Start()
        {
            // Assuming your object has a collection of children named "children"
            int childIndex = 0;
            foreach (Transform child in transform)
            {
                Vector3 newPosition = child.position + new Vector3(0f, 5f, 0f);
                if (child.name.Contains(partialName))
                {
                    GameObject.Instantiate<GameObject>(coinToSpawn, newPosition, Quaternion.identity);
                }

                childIndex++;
            }
        }
    }
}