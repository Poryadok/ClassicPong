using System.Collections.Generic;

namespace PM.PingPong.MainMenu
{
	public class LocalLobby
	{
		public List<LocalPlayerData> Players = new List<LocalPlayerData>();
		public string LobbyKey;
		public string RelayKey;
		public string LobbyName;
	}
}