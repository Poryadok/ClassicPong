using System;
using PM.PingPong.General;
using PM.UsefulThings;
using UIBinding;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class GameModeSelectionPanel : AbPanel
	{
		private readonly BoolProperty areWallsReset = new();
		
		private GameModeSelector gameModeSelector;
		private GeneralConfigHolder generalConfigHolder;

		[Inject]
		public void Construct(GameModeSelector gameModeSelector, GeneralConfigHolder generalConfigHolder)
		{
			this.gameModeSelector = gameModeSelector;
			this.generalConfigHolder = generalConfigHolder;
		}

		private void Start()
		{
			areWallsReset.value = generalConfigHolder.GameSettings.AreWallsReset;
		}

		public void PlaySolo()
		{
			gameModeSelector.PlaySolo(areWallsReset.value);
		}

		public void PlayWithBot()
		{
			gameModeSelector.PlayWithBot(areWallsReset.value);
		}

		public void Back()
		{
			gameModeSelector.Back();
		}
	}
}