using PM.UsefulThings;
using UIBinding;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameOverPanel : AbPanel
	{
		private readonly BoolProperty isVictory = new();

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
			isVictory.value = gameplayLoopController.Score.x > gameplayLoopController.Score.y;
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