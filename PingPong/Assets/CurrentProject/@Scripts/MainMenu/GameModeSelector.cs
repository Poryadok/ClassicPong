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

		public void PlaySolo()
		{
			generalConfigHolder.GameSettings.GameMode = GameMode.Solo;
			LoadGameplayScene();
		}

		public void PlayWithBot()
		{
			generalConfigHolder.GameSettings.GameMode = GameMode.Bot;
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