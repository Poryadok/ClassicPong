using UnityEngine;

namespace PM.PingPong.Gameplay
{
	public class BestScoreController
	{
		public const string BEST_SCORE_KEY = "bestScore";

		private float gameStartTime;

		private GameplayLoopController gameplayLoopController;

		public BestScoreController(GameplayLoopController gameplayLoopController)
		{
			this.gameplayLoopController = gameplayLoopController;
			gameplayLoopController.OnGameStarted += OnGameStartedHandler;
			gameplayLoopController.OnGameOver += OnGameOverHandler;
		}

		private void OnGameOverHandler()
		{
			if (gameplayLoopController.Score.x < gameplayLoopController.Score.y)
				return; // lose

			var currentScore = GetCurrentScore();

			if (!PlayerPrefs.HasKey(BEST_SCORE_KEY) || currentScore < PlayerPrefs.GetFloat(BEST_SCORE_KEY))
			{
				PlayerPrefs.SetFloat(BEST_SCORE_KEY, currentScore);
			}
		}

		public float GetCurrentScore()
		{
			return Time.time - gameStartTime;
		}

		private void OnGameStartedHandler()
		{
			gameStartTime = Time.time;
		}
	}
}