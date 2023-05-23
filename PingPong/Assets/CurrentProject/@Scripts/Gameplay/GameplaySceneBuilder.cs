using System;
using PM.PingPong.General;
using PM.PingPong.MainMenu;
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
		private GameplayConfigHolder gameplayConfigHolder;
		private WindowManagerUT windowManager;
		private GameplayStateController gameplayStateController;
		private AbRocketLogic.LogicFactory logicFactory;
		private Merchandiser merchandiser;
		
		[Inject]
		public void Construct(GameplayConfigHolder gameplayConfigHolder,
			GeneralConfigHolder generalConfigHolder, 
			WindowManagerUT windowManagerUt, 
			GameplayStateController gameplayStateController, 
			AbRocketLogic.LogicFactory logicFactory,
			Merchandiser merchandiser)
		{
			this.gameplayConfigHolder = gameplayConfigHolder;
			this.gameplayStateController = gameplayStateController;
			this.generalConfigHolder = generalConfigHolder;
			windowManager = windowManagerUt;
			this.logicFactory = logicFactory;
			this.merchandiser = merchandiser;
		}

		public void Initialize()
		{
			SetupObjects();
			windowManager.OpenNewPanel<GameplayPanel>(WindowCloseModes.CloseEverything);
			windowManager.OpenNewPanel<GameplayInputPanel>();
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

			var activeSkinId = merchandiser.GetActiveSkin();
			var activeSkin = gameplayConfigHolder.Skins.Find(x => x.Id == activeSkinId);
			var skin = Instantiate(activeSkin.Prefab, Ball.transform);
			skin.GetComponent<MeshRenderer>().material.color = activeSkin.Color;
		}
	}
}