using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollectionScript : MonoBehaviour
{
	[SerializeField] public GameObject coinPrefab;
	private GameObject coinInstance;
	private Vector3 StartPosition;
	private float rotationSpeed = 5f;

	private float bobbleSpeed = 1f;
	private float bobbleAmount = .1f;

	//public AudioClip collectSound;

	//public GameObject collectEffect;

	// Use this for initialization
	void Start()
	{
		if (coinInstance == null)
		{
			coinInstance = Instantiate(coinPrefab, new Vector3(3, 6, 8), Quaternion.identity);
			StartPosition = coinInstance.transform.position;
		}
	}


	// Update is called once per frame
	void Update()
	{
		if(coinInstance != null)
        {
			coinInstance.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
			float verticalOffset = Mathf.Sin(Time.time * bobbleSpeed) * bobbleAmount;
			coinInstance.transform.position = StartPosition + new Vector3(0f, verticalOffset, 0f);
		}
	}

}
