using UnityEngine;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public abstract class AbRocketLogic
	{
		public abstract float GetMovement(Rigidbody rocket, Rigidbody ball);

		public class LogicFactory : PlaceholderFactory<bool, AbRocketLogic>
		{
		}
		
		public class RocketLogicFactory : IFactory<bool, AbRocketLogic>
		{
			DiContainer container;

			public RocketLogicFactory(DiContainer container)
			{
				this.container = container;
			}

			public AbRocketLogic Create(bool isPlayer)
			{
				if (isPlayer)
				{
					return container.Instantiate<PlayerRocketLogic>();
				}

				return container.Instantiate<BotLogic>();
			}
		}
	}
}