using UnityEngine;

namespace PM.PingPong.Gameplay
{
	public class BotLogic : AbRocketLogic
	{
		public override float GetMovement(Rigidbody rocket, Rigidbody ball)
		{
			return Mathf.Clamp(ball.position.x - rocket.position.x, -1, 1);
		}
	}
}