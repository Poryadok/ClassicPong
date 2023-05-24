using System;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	public class Ball : MonoBehaviour
	{
		private Rigidbody myRigidbody;
		private Material material;
		private float spawnTime;
		
		private static readonly int HitPosition = Shader.PropertyToID("_HitPosition");
		private static readonly int HitTime = Shader.PropertyToID("_HitTime");

		private void Awake()
		{
			spawnTime = Time.time;
		}

		public void Init()
		{
			myRigidbody = GetComponent<Rigidbody>();
			material = GetComponentInChildren<MeshRenderer>().material;
		}

		private void ResetSpeed(float rocketVelocity)
		{
			var speedMultiplier = 1 + Mathf.Abs(rocketVelocity / (2 * 15f));
			myRigidbody.velocity = 15f * speedMultiplier *
			                     (myRigidbody.velocity + new Vector3(rocketVelocity / 15f, 0, 0)).normalized;

			if (Mathf.Abs(Vector3.Dot(myRigidbody.velocity, Vector3.forward)) < 0.1f)
			{
				var friendlyPush = 0.5f * (myRigidbody.velocity.z > 0 ? 1 : -1) * Vector3.forward;
				myRigidbody.velocity += friendlyPush;
			}
		}

		private void FixedUpdate()
		{
			if (myRigidbody == null)
			    return;
			
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

			if (!other.gameObject.CompareTag("Untagged"))
			{
				material.SetVector(HitPosition, other.contacts[0].point - transform.position);
				material.SetFloat(HitTime, Time.time - spawnTime);
			}
		}
	}
}