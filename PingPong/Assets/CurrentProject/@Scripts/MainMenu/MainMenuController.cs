using PM.UsefulThings;
using UnityEngine;
using Zenject;
using IInitializable = Zenject.IInitializable;

namespace PM.PingPong.MainMenu
{
	public class MainMenuController : MonoBehaviour, IInitializable
	{
		private WindowManagerUT windowManager;

		[Inject]
		public void Construct(WindowManagerUT windowManager)
		{
			this.windowManager = windowManager;
		}

		public void SelectGameMode()
		{
			windowManager.OpenNewPanel<GameModeSelectionPanel>(WindowCloseModes.CloseEverything);
		}

		public void Initialize()
		{
			windowManager.OpenNewPanel<MainMenuPanel>();
		}

		public void OpenShop()
		{
			windowManager.OpenNewPanel<ShopPanel>();
		}
	}
}