using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class InputFacade : MonoBehaviour
	{
		private DefaultInput input;

		private GameplayStateController gameplayStateController;
		private GameplayLoopController gameplayLoopController;

		[Inject]
		public void Construct(GameplayStateController gameplayStateController, GameplayLoopController gameplayLoopController)
		{
			this.gameplayStateController = gameplayStateController;
			this.gameplayLoopController = gameplayLoopController;
		}
		
		private void Start()
		{
			input = new DefaultInput();
			input.Player.Enable();
			
			gameplayLoopController.OnGameOver += OnGameOverHandler;
		}

		private void OnGameOverHandler()
		{
			input.Player.Disable();
		}

		public float GetMovementInput()
		{
			return input.Player.Move.ReadValue<Vector2>().x;
		}
	}
}