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

		private void ResetSpeed(float rocketVelocity)
		{
			var speedMultiplier = 1 + Mathf.Abs(rocketVelocity / (2 * 15f));
			rigidbody.velocity = 15f * speedMultiplier *
			                     (rigidbody.velocity + new Vector3(rocketVelocity / 15f, 0, 0)).normalized;

			if (Mathf.Abs(Vector3.Dot(rigidbody.velocity, Vector3.forward)) < 0.1f)
			{
				var friendlyPush = 0.1f * (rigidbody.velocity.z > 0 ? 1 : -1) * Vector3.forward;
				rigidbody.velocity += friendlyPush;
			}
		}

		private void Update()
		{
			if (rigidbody.velocity.magnitude > 15f)
			{
				rigidbody.velocity =
					Vector3.Lerp(rigidbody.velocity, rigidbody.velocity.normalized * 15f, Time.deltaTime);
			}
			else if (rigidbody.velocity.magnitude < 15f)
			{
				rigidbody.velocity = rigidbody.velocity.normalized * 15f;
			}
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