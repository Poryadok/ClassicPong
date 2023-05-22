using PM.UsefulThings;
using UIBinding;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameplayPanel : AbPanel
	{
		private IntProperty scoreBottom = new IntProperty();
		private IntProperty scoreTop = new IntProperty();
		
		private GameplayLoopController gameplayLoopController;

		[Inject]
		public void Construct(GameplayLoopController gameplayLoopController)
		{
			this.gameplayLoopController = gameplayLoopController;
		}

		public void Quit()
		{
			gameplayLoopController.Quit();
		}
	}
}