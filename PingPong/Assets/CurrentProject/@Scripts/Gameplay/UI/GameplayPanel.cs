using System;
using PM.UsefulThings;
using UIBinding;
using UnityEngine;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameplayPanel : AbPanel
	{
		private IntProperty scoreBottom = new IntProperty();
		private IntProperty scoreTop = new IntProperty();
		
		private GameplayLoopController gameplayLoopController;
		private GameplayStateController gameplayStateController;

		[Inject]
		public void Construct(GameplayLoopController gameplayLoopController, GameplayStateController gameplayStateController)
		{
			this.gameplayLoopController = gameplayLoopController;
			this.gameplayStateController = gameplayStateController;
		}

		private void Start()
		{
			gameplayLoopController.OnScoreChanged += OnScoreChangedHandler;
		}

		private void OnScoreChangedHandler(Vector2Int score)
		{
			scoreBottom.value = score.x;
			scoreTop.value = score.y;
		}

		public void Quit()
		{
			gameplayStateController.Pause();
		}
	}
}