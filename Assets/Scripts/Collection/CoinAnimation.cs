using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JiaLab3
{
	public class CoinAnimation : MonoBehaviour
	{
		private Vector3 StartPosition;
		private float rotationSpeed = 5f;

		private float bobbleSpeed = 1f;
		private float bobbleAmount = .1f;

		// Use this for initialization
		void Start()
		{
			StartPosition = transform.position;
		}


		// Update is called once per frame
		void Update()
		{
			if (this.gameObject != null)
			{
				transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
				float verticalOffset = Mathf.Sin(Time.time * bobbleSpeed) * bobbleAmount;
				transform.position = StartPosition + new Vector3(0f, verticalOffset, 0f);
			}
		}

	}
}