using UnityEngine;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class LobbyController : MonoBehaviour
	{
		public LocalLobby LocalLobby;

		private RelayFacade relayFacade;
		
		[Inject]
		public void Construct(RelayFacade relayFacade)
		{
			this.relayFacade = relayFacade;
		}

		public void StartLobby()
		{
		}

		public void JoinLobby()
		{
		}
	}
}