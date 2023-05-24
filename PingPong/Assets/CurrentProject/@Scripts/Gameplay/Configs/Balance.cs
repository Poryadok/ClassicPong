using UnityEngine;

namespace PM.PingPong.Gameplay
{
	// [CreateAssetMenu]
	public class Balance : ScriptableObject
	{
		public float BallSpeed;
		public float RocketSpeed;
		public float RocketAcceleration;
		public float RocketStopMultiplier;
		public float BallSpeedMultiplier;
		public float BallSpeedMaxOffset;
		public float HorizontalMovementDotProduct;
		public float AntiHorizontalZFix;
	}
}