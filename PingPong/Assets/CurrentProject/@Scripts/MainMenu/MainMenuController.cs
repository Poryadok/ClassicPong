using PM.UsefulThings;
using UnityEngine;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class MainMenuController : MonoBehaviour
	{
		private WindowManagerUT windowManager;

		[Inject]
		public void Construct()
		{
		}

		public void Start()
		{
			windowManager.OpenNewPanel<MainMenuPanel>();
		}

		public void SelectGameMode()
		{
			windowManager.OpenNewPanel<GameModeSelectionPanel>();
		}
	}
}