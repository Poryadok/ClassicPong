using PM.UsefulThings;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class GameModeSelectionPanel : AbPanel
	{
		private GameModeSelector gameModeSelector;

		[Inject]
		public void Construct(GameModeSelector gameModeSelector)
		{
			this.gameModeSelector = gameModeSelector;
		}

		public void PlaySolo()
		{
			gameModeSelector.PlaySolo();
		}

		public void PlayWithBot()
		{
			gameModeSelector.PlayWithBot();
		}

		public void Back()
		{
			gameModeSelector.Back();
		}
	}
}