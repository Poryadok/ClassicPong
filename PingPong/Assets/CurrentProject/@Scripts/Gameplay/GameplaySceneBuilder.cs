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
		[Inject(Id = "top")]
		public Rocket RocketTop;
		[Inject(Id = "bottom")]
		public Rocket RocketBottom;
		[Inject]
		public Ball Ball;

		private GeneralConfigHolder generalConfigHolder;
		private GameplayConfigHolder gameplayConfigHolder;
		private WindowManagerUT windowManager;
		private GameplayStateController gameplayStateController;
		private AbRocketMovement.MovementFactory movementFactory;
		private Merchandiser merchandiser;
		
		[Inject]
		public void Construct(GameplayConfigHolder gameplayConfigHolder,
			GeneralConfigHolder generalConfigHolder, 
			WindowManagerUT windowManagerUt, 
			GameplayStateController gameplayStateController, 
			AbRocketMovement.MovementFactory movementFactory,
			Merchandiser merchandiser)
		{
			this.gameplayConfigHolder = gameplayConfigHolder;
			this.gameplayStateController = gameplayStateController;
			this.generalConfigHolder = generalConfigHolder;
			windowManager = windowManagerUt;
			this.movementFactory = movementFactory;
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
			RocketBottom.movement = movementFactory.Create(true);
			RocketTop.movement = movementFactory.Create(
				!generalConfigHolder.GameModeSettings.Find(x =>
						x.GameMode == generalConfigHolder.GameSettings.GameMode)
					.IsBotPlaying);
			
			var activeSkinId = merchandiser.GetActiveSkin();
			var activeSkin = gameplayConfigHolder.Skins.Find(x => x.Id == activeSkinId);
			var skin = Instantiate(activeSkin.Prefab, Ball.transform);
			skin.GetComponent<MeshRenderer>().material.color = activeSkin.Color;
			Ball.Init();
		}
	}
}