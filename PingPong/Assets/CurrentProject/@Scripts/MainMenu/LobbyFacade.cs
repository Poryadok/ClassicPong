using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PM.PingPong.MainMenu
{
public class LobbyFacade
{
	private LobbyController lobbyController; 
	
	[Inject]
	public void Construct(LobbyController lobbyController)
	{
		this.lobbyController = lobbyController;
	}

	public void StartLobby()
	{
		lobbyController.StartLobby();
	}

	public void JoinLobby()
	{
		lobbyController.JoinLobby();
	}
}
}
