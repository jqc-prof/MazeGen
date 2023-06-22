using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JiaVincent.Lab3
{
    public class ExitSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject exit;
        private Transform secondToLastChild;
        void Start()
        {
            int childCount = transform.childCount;
            if (childCount >= 2)
            {
                secondToLastChild = transform.GetChild(childCount - 2);
                // Use the secondToLastChild transform as needed
            }
            Instantiate(exit, secondToLastChild.position + new Vector3(0f, 4.6f, 0f), Quaternion.identity);
        }
    }
}