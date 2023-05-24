using System;
using PM.UsefulThings;
using UIBinding;
using UnityEngine;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameOverPanel : AbPanel
	{
		private readonly BoolProperty isVictory = new();
		private readonly FloatProperty currentScore = new();
		private readonly FloatProperty bestScore = new();

		private GameplayLoopController gameplayLoopController;
		private GameplayStateController gameplayStateController;
		private BestScoreController bestScoreController;

		[Inject]
		public void Construct(GameplayLoopController gameplayLoopController,
			GameplayStateController gameplayStateController,
			BestScoreController bestScoreController)
		{
			this.gameplayLoopController = gameplayLoopController;
			this.gameplayStateController = gameplayStateController;
			this.bestScoreController = bestScoreController;
		}

		private void Start()
		{
			isVictory.value = gameplayLoopController.Score.x > gameplayLoopController.Score.y;
			currentScore.value = (float)Math.Round(bestScoreController.GetCurrentScore(), 2);
			bestScore.value = (float)Math.Round(PlayerPrefs.GetFloat(BestScoreController.BEST_SCORE_KEY), 2);
		}

		public void Restart()
		{
			gameplayStateController.Restart();
		}

		public void Menu()
		{
			gameplayStateController.GoToMenu();
		}
	}
}