using PM.UsefulThings;
using UIBinding;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class PausePanel : AbPanel
	{
		private GameplayStateController gameplayStateController;

		[Inject]
		public void Construct(GameplayStateController gameplayStateController)
		{
			this.gameplayStateController = gameplayStateController;
		}

		public void Restart()
		{
			gameplayStateController.Restart();	
		}

		public void Menu()
		{
			gameplayStateController.GoToMenu();
		}

		public void Back()
		{
			gameplayStateController.Unpause();
			Close();
		}
	}
}