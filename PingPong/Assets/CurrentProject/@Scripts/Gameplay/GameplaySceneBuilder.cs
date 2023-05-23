using System;
using PM.PingPong.General;
using PM.UsefulThings;
using PM.UsefulThings.Extensions;
using UnityEngine;
using Zenject;
using IInitializable = Zenject.IInitializable;

namespace PM.PingPong.Gameplay
{
	public class GameplaySceneBuilder : MonoBehaviour, IInitializable
	{
		public Rocket RocketTop;
		public Rocket RocketBottom;
		public Goal GoalTop;
		public Goal GoalBottom;
		public Rigidbody Ball;
		public Wall[] Walls;

		private GeneralConfigHolder generalConfigHolder;
		private WindowManagerUT windowManager;
		private GameplayStateController gameplayStateController;
		private AbRocketLogic.LogicFactory logicFactory;
		
		[Inject]
		public void Construct(GeneralConfigHolder generalConfigHolder, WindowManagerUT windowManagerUt, GameplayStateController gameplayStateController, AbRocketLogic.LogicFactory logicFactory)
		{
			this.gameplayStateController = gameplayStateController;
			this.generalConfigHolder = generalConfigHolder;
			windowManager = windowManagerUt;
			this.logicFactory = logicFactory;
		}

		public void Initialize()
		{
			SetupObjects();
			windowManager.OpenNewPanel<GameplayPanel>(WindowCloseModes.CloseEverything);
			gameplayStateController.StartGame();
		}

		private void SetupObjects()
		{
			Ball.transform.position = Vector3.zero;
			RocketBottom.Logic = logicFactory.Create(true);
			RocketTop.Logic = logicFactory.Create(
				!generalConfigHolder.GameModeSettings.Find(x =>
						x.GameMode == generalConfigHolder.GameSettings.GameMode)
					.IsBotPlaying);
			
			if (!generalConfigHolder.GameSettings.AreWallsReset)
			{
				foreach (var wall in Walls)
				{
					wall.GetComponent<Collider>().isTrigger = false;
				}
			}
		}
	}
}