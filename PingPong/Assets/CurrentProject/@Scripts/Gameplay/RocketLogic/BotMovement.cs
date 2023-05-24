using UnityEngine;

namespace PM.PingPong.Gameplay
{
	public class BotMovement : AbRocketMovement
	{
		public override float GetMovement(Rigidbody rocket, Rigidbody ball)
		{
			return Mathf.Clamp(ball.position.x - rocket.position.x, -1, 1);
		}
	}
}