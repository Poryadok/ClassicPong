using UnityEngine;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class RocketMovementController : MonoBehaviour
	{
		[Inject]
		public Ball Ball;
		[Inject(Id = "top")]
		public Rocket RocketTop;
		[Inject(Id = "bottom")]
		public Rocket RocketBottom;
	
		private Balance balance;
		
		[Inject]
		public void Construct(GameplayConfigHolder gameplayConfigHolder)
		{
			balance = gameplayConfigHolder.Balance;
		}
		private void FixedUpdate()
		{
			MoveRocket(RocketTop);
			MoveRocket(RocketBottom);
		}
		
		private void MoveRocket(Rocket rocket)
		{
			var value = rocket.movement.GetMovement(rocket.Rigidbody, Ball.Rigidbody);

			var targetRigidBody = rocket.Rigidbody;
			var currentVelocity = targetRigidBody.velocity;
			if (value == 0)
			{
				targetRigidBody.velocity = currentVelocity.normalized * (currentVelocity.magnitude * balance.RocketStopMultiplier);
			}
			else
			{
				targetRigidBody.velocity += value * Time.deltaTime * balance.RocketAcceleration * Vector3.right;
			}

			currentVelocity = targetRigidBody.velocity;

			if (currentVelocity.magnitude > balance.RocketSpeed)
			{
				targetRigidBody.velocity = currentVelocity.normalized * balance.RocketSpeed;
			}
		}
	}
}