using System;
using UnityEngine;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class BallMovementController : MonoBehaviour
	{
		[Inject]
		public Ball Ball;

		private Balance balance;
		
		[Inject]
		public void Construct(GameplayConfigHolder gameplayConfigHolder)
		{
			balance = gameplayConfigHolder.Balance;
		}
		
		private void Start()
		{
			Ball.OnRocketHit += OnBallHitRocketHandler;
		}

		private void OnDestroy()
		{
			Ball.OnRocketHit -= OnBallHitRocketHandler;
		}

		private void OnBallHitRocketHandler(float rocketSpeed)
		{
			ResetSpeed(rocketSpeed);
		}

		private void ResetSpeed(float rocketSpeed)
		{
			var speedMultiplier = 1 + Mathf.Abs(rocketSpeed / (balance.BallSpeedMultiplier * balance.RocketSpeed));
			Ball.Rigidbody.velocity = balance.BallSpeed * speedMultiplier *
			                          (Ball.Rigidbody.velocity + new Vector3(rocketSpeed / balance.RocketSpeed, 0, 0)).normalized;

			if (Mathf.Abs(Vector3.Dot(Ball.Rigidbody.velocity, Vector3.forward)) < balance.HorizontalMovementDotProduct)
			{
				var friendlyPush = balance.AntiHorizontalZFix * (Ball.Rigidbody.velocity.z > 0 ? 1 : -1) * Vector3.forward;
				Ball.Rigidbody.velocity += friendlyPush;
			}
		}

		private void FixedUpdate()
		{
			if (Ball.Rigidbody == null)
				return;
			
			if (Ball.Rigidbody.velocity != Vector3.zero && Math.Abs(Ball.Rigidbody.velocity.magnitude - balance.BallSpeed) > balance.BallSpeedMaxOffset)
			{
				Ball.Rigidbody.velocity =
					Vector3.Lerp(Ball.Rigidbody.velocity, Ball.Rigidbody.velocity.normalized * balance.BallSpeed, Time.deltaTime);
			}
		}

	}
}