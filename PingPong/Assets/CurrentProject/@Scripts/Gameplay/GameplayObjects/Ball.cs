using System;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	public class Ball : MonoBehaviour
	{
		private Rigidbody rigidbody;
		
		private void Awake()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		private void ResetSpeed()
		{
			rigidbody.velocity = rigidbody.velocity.normalized * 15f;
		}

		public void OnCollisionExit(Collision other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				ResetSpeed();
			}
		}
	}
}