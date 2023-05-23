using PM.PingPong.MainMenu;

namespace PM.PingPong.Gameplay
{
	public class RewardCollector
	{
		private Merchandiser merchandiser;
		private GameplayLoopController gameplayLoopController;

		public RewardCollector(GameplayLoopController gameplayLoopController,
			Merchandiser merchandiser)
		{
			this.gameplayLoopController = gameplayLoopController;
			this.merchandiser = merchandiser;
			
			gameplayLoopController.OnGameOver += OnGameOverHandler;
		}

		private void OnGameOverHandler()
		{
			if (gameplayLoopController.IsVictory)
			{
				merchandiser.AddProgressToCurrentItem();
			}
		}
	}
}