using PM.UsefulThings;
using UnityEngine;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class MainMenuPanel : AbPanel
	{
		private MainMenuController mainMenuController;

		[Inject]
		public void Construct(MainMenuController mainMenuController)
		{
			this.mainMenuController = mainMenuController;
		}

		public void SelectGameMode()
		{
			mainMenuController.SelectGameMode();
		}
	}
}