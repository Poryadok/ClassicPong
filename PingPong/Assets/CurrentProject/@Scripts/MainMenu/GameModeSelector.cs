using PM.PingPong.General;
using PM.UsefulThings;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class GameModeSelector
	{
		private GeneralConfigHolder generalConfigHolder;
		private WindowManagerUT windowManager;
		
		[Inject]
		public void Construct(GeneralConfigHolder generalConfigHolder, WindowManagerUT windowManager)
		{
			this.generalConfigHolder = generalConfigHolder;
			this.windowManager = windowManager;
		}

		public void PlaySolo(bool areWallsReset)
		{
			generalConfigHolder.GameSettings.GameMode = GameMode.Solo;
			generalConfigHolder.GameSettings.AreWallsReset = areWallsReset;
			LoadGameplayScene();
		}

		public void PlayWithBot(bool areWallsReset)
		{
			generalConfigHolder.GameSettings.GameMode = GameMode.Bot;
			generalConfigHolder.GameSettings.AreWallsReset = areWallsReset;
			LoadGameplayScene();
		}

		private void LoadGameplayScene()
		{
			SceneManager.LoadScene("Gameplay");
		}

		public void Back()
		{
			windowManager.OpenNewPanel<MainMenuPanel>(WindowCloseModes.CloseEverything);
		}
	}
}