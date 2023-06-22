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
        private string partialName2 = "FalseCell";

        void Start()
        {

            int childCount = transform.childCount;
            for (int childIndex = 1; childIndex < childCount; childIndex += 2)
            {
                Transform currentChild = transform.GetChild(childIndex - 1);
                Transform nextChild = transform.GetChild(childIndex);

                // Check if current or next child's name contains the partial match
                if (currentChild.name.Contains(partialName) && nextChild.name.Contains(partialName2))
                {
                    GameObject.Instantiate<GameObject>(coinToSpawn, currentChild.position + new Vector3(0f, 5f, 0f), Quaternion.identity);
                }
            }
        }
    }
}