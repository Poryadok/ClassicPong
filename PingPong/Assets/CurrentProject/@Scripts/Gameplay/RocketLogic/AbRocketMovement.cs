using UnityEngine;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public abstract class AbRocketMovement
	{
		public abstract float GetMovement(Rigidbody rocket, Rigidbody ball);

		public class MovementFactory : PlaceholderFactory<bool, AbRocketMovement>
		{
		}
		
		public class RocketMovementFactory : IFactory<bool, AbRocketMovement>
		{
			DiContainer container;

			public RocketMovementFactory(DiContainer container)
			{
				this.container = container;
			}

			public AbRocketMovement Create(bool isPlayer)
			{
				if (isPlayer)
				{
					return container.Instantiate<PlayerRocketMovement>();
				}

				return container.Instantiate<BotMovement>();
			}
		}
	}
}