using System;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	public class Ball : MonoBehaviour
	{
		private Rigidbody myRigidbody;

		private void Awake()
		{
			myRigidbody = GetComponent<Rigidbody>();
		}

		private void ResetSpeed(float rocketVelocity)
		{
			var speedMultiplier = 1 + Mathf.Abs(rocketVelocity / (2 * 15f));
			myRigidbody.velocity = 15f * speedMultiplier *
			                     (myRigidbody.velocity + new Vector3(rocketVelocity / 15f, 0, 0)).normalized;

			if (Mathf.Abs(Vector3.Dot(myRigidbody.velocity, Vector3.forward)) < 0.1f)
			{
				var friendlyPush = 0.1f * (myRigidbody.velocity.z > 0 ? 1 : -1) * Vector3.forward;
				myRigidbody.velocity += friendlyPush;
			}
		}

		private void FixedUpdate()
		{
			if (myRigidbody.velocity != Vector3.zero && Math.Abs(myRigidbody.velocity.magnitude - 15f) > 0.1f)
			{
				myRigidbody.velocity =
					Vector3.Lerp(myRigidbody.velocity, myRigidbody.velocity.normalized * 15f, Time.deltaTime);
			}
			// else if (rigidbody.velocity.magnitude < 15f)
			// {
			// 	rigidbody.velocity = rigidbody.velocity.normalized * 15f;
			// }
		}

		public void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				ResetSpeed(other.gameObject.GetComponent<Rigidbody>().velocity.x);
			}
		}
	}
}