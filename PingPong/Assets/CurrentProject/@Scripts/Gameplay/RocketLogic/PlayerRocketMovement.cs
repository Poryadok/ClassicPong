using UnityEngine;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class PlayerRocketMovement : AbRocketMovement
	{
		private InputFacade input;

		[Inject]
		public void Construct(InputFacade inputFacade)
		{
			input = inputFacade;
		}
		
		public override float GetMovement(Rigidbody rocket, Rigidbody ball)
		{
			return input.GetMovementInput();
		}
	}
}