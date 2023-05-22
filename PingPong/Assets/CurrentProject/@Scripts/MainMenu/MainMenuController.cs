using PM.UsefulThings;
using UnityEngine;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class MainMenuController : MonoBehaviour
	{
		private LobbyFacade lobbyFacade;
		private WindowManagerUT windowManager;

		[Inject]
		public void Construct()
		{
		}

		public void Start()
		{
			windowManager.OpenNewPanel<MainMenuPanel>();
		}

		public void StartLobby()
		{
			lobbyFacade.StartLobby();
		}

		public void JoinLobby()
		{
			lobbyFacade.JoinLobby();
		}
	}
}